using DanaZhangCms.Core;
using DanaZhangCms.Core.Helpers;
using DanaZhangCms.Core.IoC;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DanaZhangCms
{
    public abstract class BaseController : Controller
    {
       
        public BaseController( )
        { 
        }


        //工作上下文
        public WebWorkContext WorkContext = new WebWorkContext();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _bannerRepository = AspectCoreContainer.Resolve<IBannerRepository>();
            var filePath = System.IO.Path.Combine(GlobalConfiguration.ApplicationPath, "XmlConfig", "site.config");
            var site = XmlHelper.XmlDeserializeFromFile<SiteXml>(filePath, System.Text.Encoding.UTF8);
            var banners = _bannerRepository.Get().ToList();
            var _contentsRepository = AspectCoreContainer.Resolve<IContentsRepository>();
            var contents = _contentsRepository.Where(p => p.IsDeleted == false).OrderByDescending(o=>o.SortId).Select(o=>new Models.Contents() { Title=o.Title,SpellName=o.SpellName,Content=o.Content}).ToList();
            WorkContext.Sites = site;
            WorkContext.Banners = banners;
            WorkContext.Content = contents; 
            var _proRepository = AspectCoreContainer.Resolve<IProductRepository>();
            var _cateRepository = AspectCoreContainer.Resolve<IProductCategoryRepository>();
            var position = _proRepository.Where(p=>p.IsDeleted==false).ToList();
            ViewBag.ProductList = position;
            ViewBag.CategoryList = _cateRepository.ToList();

            ViewBag.SeoTitle = site.SeoTitle;
            ViewBag.SeoKeyword = site.SeoKeyword;
            ViewBag.SeoDescription = site.SeoDescription;

            var script = contents.FirstOrDefault(o => o.SpellName == "Baidu");
            ViewBag.SeoScript = script;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.WorkContext = WorkContext;
            ViewBag.Title = WorkContext.Sites.webname; 
        }
    }
}