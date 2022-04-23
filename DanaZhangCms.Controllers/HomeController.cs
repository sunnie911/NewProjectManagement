using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DanaZhangCms.Controllers
{
    [Ignore]
    public class HomeController : BaseController
    {
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;

        private IBannerRepository _banRepository;

        private IProductCategoryRepository _cateRepository;

        
        public HomeController(IProductCategoryRepository cateRepository,IProductRepository proRepository, IArticleRepository artRepository, IBannerRepository banRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _banRepository = banRepository;
            _cateRepository = cateRepository;
        }

        ///首页
        public IActionResult Index()
        {

            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.Where(o=>o.IsHot==true).Take(8).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl,IsHot=o.IsHot }).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4).OrderByDescending(o => o.Id).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3).OrderByDescending(o => o.Id).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var banners = _banRepository.Take(5).ToList();
            var logos = articleList.Where(a => a.CategoryId == 5).OrderByDescending(o => o.Id).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            model.Banners = banners;
            model.Logos = logos;

            var position = _proRepository.ToList();
            ViewBag.ProductList = position;
            ViewBag.CategoryList = _cateRepository.ToList();

            return View(model);
        }

       
    }
}