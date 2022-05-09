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
        public EnglishController( IProductRepository proRepository, IArticleRepository artRepository, IBannerRepository banRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _banRepository = banRepository;
        
        }

        ///首页
        public IActionResult Index()
        {

            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.Where(o=>o.IsHot==true).Take(8).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl,IsHot=o.IsHot }).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4).OrderByDescending(o => o.CreatedDate).Take(3).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3).OrderByDescending(o => o.Id).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var banners = _banRepository.Take(5).ToList();
            var logos = articleList.Where(a => a.CategoryId == 5).OrderByDescending(o => o.Id).Take(10).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            model.Banners = banners;
            model.Logos = logos;

          
            return View("~/Views/English/Index.cshtml", model);
        }

        ///首页
        public IActionResult Article(int page = 1, int pageSize = 12)
        {

            var arts = _artRepository.Where(o => o.CategoryId == 4).OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, VedioUrl = o.VedioUrl, CreatedDate = o.CreatedDate, ClickCount = o.ClickCount, Content = o.Content }).ToList();
            var total = _artRepository.Where(o => o.CategoryId == 4).Count();
            ViewBag.Total = total;

            return View("~/Views/English/Article/Index.cshtml", arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> NewDetail(int id)
        {
            var model = await _artRepository.GetSingleAsync(id);
            var preArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.Id > id).Skip(1).ToList();
            var LastArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.Id < id).Skip(1).ToList();

            if (preArticle != null && preArticle.Count > 0)
            {
                ViewBag.PreArticle = preArticle[0];
            }

            if (LastArticle != null && LastArticle.Count > 0)
            {
                ViewBag.LastArticle = LastArticle[0];
            }
            return View("~/Views/English/Article/Index.cshtml", model);
        }
        ///首页
        public IActionResult Product(int page, int categoryId, int pageSize = 10)
        {
            if (page == 0)
            {
                page = 1;
            }

            List<Product> productList = new List<Product>();
            var total = _proRepository.Count();
            if (categoryId > 0)
            {
                productList = _proRepository.Where(p => p.CategoryId == categoryId).OrderBy(o => o.IsHot).Skip((page - 1) * pageSize).ToList();
                total = _proRepository.Where(p => p.CategoryId == categoryId).Count();
            }
            else
            {
                productList = _proRepository.OrderBy(o => o.IsHot).Skip((page - 1) * pageSize).Take(pageSize).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl, IsHot = o.IsHot }).ToList();

            }

            ViewBag.Total = total;
            return View("~/Views/English/Product/Index.cshtml", productList);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProDetail(int id)
        {
            var model = await _proRepository.GetSingleAsync(id);

            return View("~/Views/English/Product/Detail.cshtml", model);
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        { 
            return View("~/Views/About/AboutEn.cshtml");
        }

        ///首页
        public IActionResult Vedio(int page = 1)
        {

            var arts = _artRepository.Where(o => o.IsDeleted == false && o.CategoryId == 3).OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, VedioUrl = o.VedioUrl, CreatedDate = o.CreatedDate, ClickCount = o.ClickCount, Content = o.Content }).ToList();
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
            var model = await _artRepository.GetSingleAsync(id);
            return View("~/Views/English/Vedio/Detail.cshtml", model);
        }
    }
}