using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms
{
    [Ignore]
    public class EnglishController : BaseController
    {
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        private IBannerRepository _banRepository;
        private IContentsRepository _conRepository;
        public EnglishController( IProductRepository proRepository, IArticleRepository artRepository, IBannerRepository banRepository, IContentsRepository contentRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _banRepository = banRepository;
            _conRepository = contentRepository;

        }

        ///首页
        public IActionResult Index()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/index");
            }
            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.Where(o=>o.IsHot==true).OrderBy(o => o.SortId).Take(8).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4).OrderBy(o => o.SortId).Take(3) .ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3).OrderBy(o => o.SortId).Take(10) .ToList();
            var banners = _banRepository.Take(5).ToList();
            var logos = articleList.Where(a => a.CategoryId == 5).OrderBy(o => o.SortId).Take(10).ToList();

            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            model.Banners = banners;
            model.Logos = logos;

            var cases = articleList.Where(a => a.CategoryId == 8).OrderBy(o => o.SortId).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            model.Cases = cases;
            return View("~/Views/English/Index.cshtml", model);
        }

        ///首页
        public IActionResult Article(int categoryId = 4,int page = 1, int pageSize = 12)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/article");
            }

            var arts = _artRepository.Where(o => o.CategoryId == categoryId).OrderBy(o => o.SortId).ThenByDescending(o => o.CreatedDate).ToList();
            var total = _artRepository.Where(o => o.CategoryId == categoryId).Count();
            ViewBag.Total = total;

            ViewBag.CategoryId = categoryId;

            return View("~/Views/English/Article/Index.cshtml", arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> NewDetail(int id)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/newDetail/" + id);
            }

           
            var model = await _artRepository.GetSingleAsync(id);
            var preArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.Id > id).Skip(1).ToList();
            var LastArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.Id < id).Skip(1).ToList();

            ViewBag.CategoryId = model.CategoryId;

            if (preArticle != null && preArticle.Count > 0)
            {
                ViewBag.PreArticle = preArticle[0];
            }

            if (LastArticle != null && LastArticle.Count > 0)
            {
                ViewBag.LastArticle = LastArticle[0];
            }
            return View("~/Views/English/Article/Detail.cshtml", model);
        }
        ///首页
        public IActionResult Product(int categoryId, string word)
        {

            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/product");
            }
            List<Product> productList = new List<Product>(); 
            if (categoryId > 0)
            {
                productList = _proRepository.Where(p => p.CategoryId == categoryId).OrderBy(o => o.IsHot).ToList();
              
            }
            else
            {
                productList = _proRepository.OrderBy(o => o.IsHot).ToList();

            }
            if (!string.IsNullOrWhiteSpace(word))
            {
                productList = _proRepository.Where(p => p.NameEn.Contains(word) || p.Model1.Contains(word)).OrderBy(o => o.IsHot).ToList();

            }


            return View("~/Views/English/Product/Index.cshtml", productList);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProDetail(int id)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/proDetail/" + id);
            }
            var model = await _proRepository.GetSingleAsync(id);

            var contents = _conRepository.Where(p => p.ProductId == id).ToList();

            ProductView view = new ProductView() { Product = model };
            view.Details = contents.Where(p => p.Type == "规格参数" && p.SpellName == "china").ToList();
            view.DetailsEn = contents.Where(p => p.Type == "规格参数" && p.SpellName == "english").ToList();
            view.Downfiles = contents.Where(p => p.Type == "相关下载").ToList();

            ViewBag.SeoTitle = model.Name + "冠力科技";

            return View("~/Views/English/Product/Detail.cshtml", view);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <returns></returns>
        public IActionResult Download()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/download");
            }
            
            return View("~/Views/English/Product/DownLoad.cshtml");
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/about");
            }
            return View("~/Views/About/AboutEn.cshtml");
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public IActionResult join()
        {

            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/join");
            }
            
            return View("~/Views/Contact/join.cshtml");
        }
        ///首页
        public IActionResult Vedio(int page = 1)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/vedio");
            }
            var arts = _artRepository.Where(o => o.IsDeleted == false && o.CategoryId == 3).OrderBy(o => o.SortId).ToList();
            var total = _artRepository.Where(o => o.IsDeleted == false && o.CategoryId == 3).Count();
            ViewBag.Total = total;
          
            return View("~/Views/English/Vedio/Index.cshtml", arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> VedioDetail(int id)
        {

            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobileEn/VedioDetail/" + id);
            }
            var model = await _artRepository.GetSingleAsync(id);
            return View("~/Views/English/Vedio/Detail.cshtml", model);
        }
    }
}