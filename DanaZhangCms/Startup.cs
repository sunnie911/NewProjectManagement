using DanaZhangCms.Core;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.Core.Filters;
using DanaZhangCms.Core.Helpers;
using DanaZhangCms.Core.IoC;
using DanaZhangCms.Core.Options;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DanaZhangCms
{

    public class Startup
    {
        public static ILoggerRepository Repository { get; set; }
        private readonly IHostingEnvironment hostingEnvironments;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            //初始化log4net
            Repository = LogManager.CreateRepository("DanaZhangCmsRepository");
            Log4NetHelper.SetConfig(Repository, "log4net.config");
            hostingEnvironments = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.ContentPath = hostingEnvironments.WebRootPath;
            GlobalConfiguration.ApplicationPath = hostingEnvironments.ContentRootPath;
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });
            return InitIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseAuthentication()
                .UseMvc(routes =>
                {
                    routes.MapRoute(
              name: "newsDetail",
              template: "news/{id}.html",
              defaults: new { controller = "Article", action = "Detail" }

          );
                    routes.MapRoute(
                        name: "Content",
                        template: "{spellname}",
                        defaults: new { controller = "Content", action = "Index", spellname = "" },
                        constraints: new { customConstraint = new RouteData.ChannelConstraint(app) });
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });

            InitializeDatabase(app);
        }
        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider InitIoC(IServiceCollection services)
        {
            //database connectionstring
            var dbConnectionString = Configuration.GetConnectionString("SQLite");

            #region Redis

            //var redisConnectionString = Configuration.GetConnectionString("Redis");
            ////启用Redis
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = redisConnectionString;//redis连接字符串
            //    option.InstanceName = "sample";//Redis实例名称
            //});
            //全局设置Redis缓存有效时间为5分钟。
            //services.Configure<DistributedCacheEntryOptions>(option =>
            //    option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5));

            #endregion

            #region MemoryCache

            //启用MemoryCache
            //services.AddMemoryCache();

            #endregion

            #region 配置DbContextOption

            //配置DbContextOption
            services.Configure<DbContextOption>(options =>
            {
                options.ConnectionString = dbConnectionString;
                options.ModelAssemblyName = "CompanyCms.Models";
            });

            #endregion

            #region 配置CodeGenerateOption

            var currentDirectory = System.Environment.CurrentDirectory;
            var path = Directory.GetParent(currentDirectory).FullName;


            //配置CodeGenerateOption
            services.Configure<CodeGenerateOption>(options =>
            {
                options.OutputPath = path;
                options.ModelsNamespace = "CompanyCms.Models";
                options.IRepositoriesNamespace = "CompanyCms.IRepositories";
                options.RepositoriesNamespace = "CompanyCms.Repositories";
                options.ControllersNamespace = "CompanyCms.Controllers";
            });

            #endregion

            #region 各种注入

            services.AddSingleton(Configuration)//注入Configuration，ConfigHelper要用
                .AddTransient<IDbContextCore, SQLiteDbContext>()//注入EF上下文
                .AddTransient<IImageProcessor, ImageSharpProcessor>()
                .AddTransient<IMediaService, LocalMediaService>()
                .AddTransientAssembly("CompanyCms.IRepositories", "CompanyCms.Repositories");//注入仓储

            #endregion

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Index";
                    options.LogoutPath = "/Account/Logout";
                });
            services.AddOptions();
            services.AddMvc(option =>
                {
                    option.Filters.Add(new GlobalExceptionFilter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices();


            return AspectCoreContainer.BuildServiceProvider(services);//接入AspectCore.Injector
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userRepository = serviceScope.ServiceProvider.GetService<IRepositories.ISysUserRepository>();
                var options = serviceScope.ServiceProvider.GetService<Microsoft.Extensions.Options.IOptions<CodeGenerateOption>>();
                if (!userRepository.Exist(m => m.SysUserName.Equals("admin", StringComparison.OrdinalIgnoreCase) && m.Activable))
                {
                    InitSysMenus(app, options.Value.ControllersNamespace);
                    userRepository.Add(new Models.SysUser()
                    {
                        SysUserName = "admin",
                        Activable = true,
                        EMail = "admin@danazhangcms.com",
                        Password = "123456",
                        Telephone = "15588888888"
                    });
                }
            }
        }



        /// <summary>
        /// 初始化系统菜单
        /// </summary>
        private void InitSysMenus(IApplicationBuilder app, string controllerAssemblyName)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var menuRepository = serviceScope.ServiceProvider.GetService<IRepositories.ISysMenuRepository>();
                var assembly = Assembly.Load(controllerAssemblyName);
                var types = assembly?.GetTypes();
                var list = types?.Where(t => !t.IsAbstract && t.IsPublic && t.IsSubclassOf(typeof(Controller))).ToList();
                if (list != null)
                {
                    foreach (var type in list)
                    {
                        var controllerName = type.Name.Replace("Controller", "");
                        if (!controllerName.Contains("Sys") || controllerName.Equal("SysManage"))
                        {
                            continue;
                        }
                        var methods = type.GetMethods().Where(m =>
                            m.IsPublic && (m.ReturnType == typeof(IActionResult) ||
                                           m.ReturnType == typeof(Task<IActionResult>)));
                        var parentIdentity = $"{controllerName}";
                        if (menuRepository.Count(m => m.Identity.Equals(parentIdentity, StringComparison.OrdinalIgnoreCase)) == 0)
                        {
                            menuRepository.Add(new Models.SysMenu()
                            {
                                MenuName = type.GetCustomAttribute<ControllerDescriptionAttribute>()?.Name ?? parentIdentity,
                                Activable = true,
                                Visiable = true,
                                Identity = parentIdentity,
                                RouteUrl = "",
                                ParentId = null
                            }, true);
                        }

                        foreach (var method in methods)
                        {
                            if (method.GetCustomAttribute<DanaZhangCms.Core.Attributes.IgnoreAttribute>() == null)
                            {
                                var identity = $"{controllerName}/{method.Name}";
                                if (menuRepository.Count(m => m.Identity.Equals(identity, StringComparison.OrdinalIgnoreCase)) == 0)
                                {
                                    menuRepository.Add(new Models.SysMenu()
                                    {
                                        MenuName = method.GetCustomAttribute<ActionDescriptionAttribute>()?.Name ?? method.Name,
                                        Activable = true,
                                        Visiable = method.GetCustomAttribute<Core.Attributes.AjaxRequestOnlyAttribute>() == null,
                                        Identity = identity,
                                        RouteUrl = identity,
                                        ParentId = identity.Equals(parentIdentity, StringComparison.OrdinalIgnoreCase)
                                            ? null
                                            : menuRepository.GetSingleOrDefault(x => x.Identity == parentIdentity)?.Id
                                    }, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
