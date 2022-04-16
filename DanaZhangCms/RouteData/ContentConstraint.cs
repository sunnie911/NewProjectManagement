using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace DanaZhangCms.RouteData
{
    /// <summary>
    /// 频道匹配
    /// </summary>
    public class ChannelConstraint : IRouteConstraint
    {
        public List<DanaZhangCms.Models.Contents> cates = new List<Models.Contents>();
        public ChannelConstraint(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var repository = serviceScope.ServiceProvider.GetService<IRepositories.IContentsRepository>();
                cates = repository.ToList();
            }
        }
        public bool Match(Microsoft.AspNetCore.Http.HttpContext httpContext, IRouter route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.ContainsKey("spellname"))
            {
                var cate = values["spellname"].ToString().Trim().ToLower();
                var result = cates.Any(s => s.SpellName.Trim().ToLower() == cate);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
