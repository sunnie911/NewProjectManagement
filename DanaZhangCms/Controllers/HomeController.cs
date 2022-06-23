using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DanaZhangCms
{
    [Ignore]
    public class HomeController : BaseController
    {
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        private IBannerRepository _banRepository;
        private IContentsRepository _contentRepository;
        public HomeController( IProductRepository proRepository, IArticleRepository artRepository, IBannerRepository banRepository, IContentsRepository contentRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _banRepository = banRepository;
            _contentRepository = contentRepository;
        
        }

        ///首页
        public IActionResult Index()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

           
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/index");
            }

            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.Where(o=>o.IsHot==true && o.IsDeleted == false).OrderBy(o => o.SortId).Take(8).Select(o => new Product() { Name = o.Name,Model1=o.Model1, Id = o.Id, ImgUrl = o.ImgUrl,IsHot=o.IsHot }).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4&&a.IsDeleted==false).OrderBy(o => o.SortId).Take(3).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3 && a.IsDeleted == false).OrderBy(o => o.SortId).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var banners = _banRepository.Take(5).ToList();
            var logos = articleList.Where(a => a.CategoryId == 5 && a.IsDeleted == false).OrderBy(o => o.SortId).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            var cases = articleList.Where(a => a.CategoryId == 8 && a.IsDeleted == false).OrderBy(o => o.SortId).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            model.Cases = cases;
            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            model.Banners = banners;
            model.Logos = logos;
            model.Cases = cases;
            var profile = _contentRepository.FirstOrDefault(o => o.SpellName == "CompanyProfile");
            ViewBag.CompanyProfile = profile;


            return View(model);
        }

      

    }
}