using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.CodeGenerator;
using DanaZhangCms.Core.Options;
 
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
 
using DanaZhangCms.ViewModels;

namespace DanaZhangCms
{
    [Ignore, ControllerDescription(Name = "首页")]
    public class SysManageController : SysBaseController
    {

        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        private ISysMenuRepository menuRepository;
        private ISysUserRepository userRepository;
        public SysManageController(IProductRepository proRepository, IArticleRepository artRepository, ISysMenuRepository menuRepository, ISysUserRepository userRepository)
        {
           
            CodeGenerator.Generate();//生成所有实体类对应的Repository层代码文件
            this.menuRepository = menuRepository;
            this.userRepository = userRepository;
            this._proRepository = proRepository;
            this._artRepository = artRepository;
        }
        [ActionDescription(Name = "首页")]
        public IActionResult Index()
        {
            CodeGenerator.Generate();//生成所有实体类对应的Repository层代码文件
            return View();
        }

        [ActionDescription(Name = "系统信息")]
        public IActionResult Welcome()
        {
            ViewData["Title"] = "系统信息";

            SiteView view = new SiteView();
            view.Articles = _artRepository.Where(o => o.CategoryId == 4).Count();
            view.Logos= _artRepository.Where(o => o.CategoryId == 5).Count();
            view.Vedios = _artRepository.Where(o => o.CategoryId == 3).Count();
            view.Products = _proRepository.Count();

            ViewBag.SiteView = view;
            return View();
        }

        [AllowAnonymous]
        [ActionDescription(Name = "初始化菜单")]
        public IActionResult Init([FromServices]IOptions<CodeGenerateOption> options)
        {
            InitSysMenus(options.Value.ControllersNamespace);
            if (!userRepository.Exist(m => m.SysUserName.Equals("admin", StringComparison.OrdinalIgnoreCase) && m.Activable))
            {
                userRepository.Add(new SysUser()
                {
                    SysUserName = "admin",
                    Activable = true,
                    EMail = "admin@danazhangcms.com",
                    Password = "123456",
                    Telephone = "15588888888"
                });
            }
            return Ok();
        }

        /// <summary>
        /// 初始化系统菜单
        /// </summary>
        private void InitSysMenus(string controllerAssemblyName)
        {
            var assembly = Assembly.Load(controllerAssemblyName);
            var types = assembly?.GetTypes();
            var list = types?.Where(t => !t.IsAbstract && t.IsPublic && t.IsSubclassOf(typeof(Controller))).ToList();
            if (list != null)
            {
                foreach (var type in list)
                {
                    var controllerName = type.Name.Replace("Controller", "");
                    var methods = type.GetMethods().Where(m =>
                        m.IsPublic && (m.ReturnType == typeof(IActionResult) ||
                                       m.ReturnType == typeof(Task<IActionResult>)));
                    var parentIdentity = $"{controllerName}";
                    if (menuRepository.Count(m => m.Identity.Equals(parentIdentity, StringComparison.OrdinalIgnoreCase)) == 0)
                    {
                        menuRepository.Add(new SysMenu()
                        {
                            MenuName = type.GetCustomAttribute<ControllerDescriptionAttribute>()?.Name??parentIdentity,
                            Activable = true,
                            Visiable = true,
                            Identity = parentIdentity,
                            RouteUrl = "",
                            ParentId = null
                        }, true);
                    }

                    foreach (var method in methods)
                    {
                        var identity = $"{controllerName}/{method.Name}";
                        if (menuRepository.Count(m => m.Identity.Equals(identity, StringComparison.OrdinalIgnoreCase)) == 0)
                        {
                            menuRepository.Add(new SysMenu()
                            {
                                MenuName = method.GetCustomAttribute<ActionDescriptionAttribute>()?.Name ?? method.Name,
                                Activable = true,
                                Visiable = method.GetCustomAttribute<AjaxRequestOnlyAttribute>() == null,
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                menuRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
