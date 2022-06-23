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
    public class MobileController : BaseController
    {
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        private IBannerRepository _banRepository;
        private IContentsRepository _repository;
        public MobileController( IProductRepository proRepository, IArticleRepository artRepository, IBannerRepository banRepository, IContentsRepository repository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _banRepository = banRepository;
            _repository = repository;


        }

        ///首页
        public IActionResult Index()
        {
            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.Where(o=>o.IsHot==true).Take(8).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4).OrderByDescending(o => o.Id).Take(4).ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3).OrderByDescending(o => o.Id).Take(10) .ToList();
            var banners = _banRepository.Take(5).ToList();
            var logos = articleList.Where(a => a.CategoryId == 5).OrderByDescending(o => o.Id).Take(10).ToList();

            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            model.Banners = banners;
            model.Logos = logos;

            var profile = _repository.FirstOrDefault(o => o.SpellName == "CompanyProfile");
            ViewBag.CompanyProfile = profile;

            return View("~/Views/Mobile/Index.cshtml", model);
        }

        ///首页
        public IActionResult Article(int page = 1, int pageSize = 12)
        {

            var arts = _artRepository.Where(o => o.CategoryId == 4).OrderBy(o => o.SortId).ThenByDescending(o => o.CreatedDate).ToList();
            var total = _artRepository.Where(o => o.CategoryId == 4).Count();
            ViewBag.Total = total;

            return View("~/Views/Mobile/Article/Index.cshtml", arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> NewDetail(int id)
        {
            var model = await _artRepository.GetSingleAsync(id);
            var preArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.SortId > model.SortId).OrderBy(o => o.SortId).Skip(1).ToList();
            var LastArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.SortId < model.SortId).OrderBy(o => o.SortId).Skip(1).ToList();

            if (preArticle != null && preArticle.Count > 0)
            {
                ViewBag.PreArticle = preArticle[0];
            }

            if (LastArticle != null && LastArticle.Count > 0)
            {
                ViewBag.LastArticle = LastArticle[0];
            }
            return View("~/Views/Mobile/Article/Detail.cshtml", model);
        }
        ///首页
        public IActionResult Product(  int categoryId,string word)
        {
           

            List<Product> productList = new List<Product>();
            var total = _proRepository.Count();
            if (categoryId > 0)
            {
                productList = _proRepository.Where(p => p.CategoryId == categoryId).OrderBy(o => o.IsHot).ToList();
                total = _proRepository.Where(p => p.CategoryId == categoryId).Count();
            }
            else
            {
                productList = _proRepository.OrderBy(o => o.IsHot).ToList();

            }
            if (!string.IsNullOrWhiteSpace(word))
            {
                productList = _proRepository.Where(p => p.Name.Contains(word) || p.Model1.Contains(word)).OrderBy(o => o.IsHot).ToList();
            }
            ViewBag.Total = total;
            return View("~/Views/Mobile/Product/Index.cshtml", productList);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProDetail(int id)
        {


            var model = await _proRepository.GetSingleAsync(id); 
            var contents = _repository.Where(p => p.ProductId == id).ToList();

            ProductView view = new ProductView() { Product = model };
            view.Details = contents.Where(p => p.Type == "规格参数" && p.SpellName == "china").ToList();
            view.DetailsEn = contents.Where(p => p.Type == "规格参数" && p.SpellName == "english").ToList();
            view.Downfiles = contents.Where(p => p.Type == "相关下载").ToList();

            ViewBag.SeoTitle = model.Name + "冠力科技";
            return View("~/Views/Mobile/Product/Detail.cshtml", view);
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View("~/Views/About/mobile.cshtml");
        }

        /// <summary>
        /// 联系我们
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            return View("~/Views/Contact/mobile.cshtml");
        }

        ///首页
        public IActionResult Vedio(int page = 1)
        {
            var arts = _artRepository.Where(o => o.IsDeleted == false && o.CategoryId == 3).OrderBy(o => o.SortId).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, VedioUrl = o.VedioUrl, CreatedDate = o.CreatedDate, ClickCount = o.ClickCount, Content = o.Content }).ToList();
            var total = _artRepository.Where(o => o.IsDeleted == false && o.CategoryId == 3).Count();
            ViewBag.Total = total;
            return View("~/Views/Mobile/Vedio/Index.cshtml", arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> VedioDetail(int id)
        {
            var model = await _artRepository.GetSingleAsync(id);
            return View("~/Views/Mobile/Vedio/Detail.cshtml", model);
        }

        public IActionResult Join(string spellname = "")
        { 
            var model = _repository.FirstOrDefault(o => o.SpellName == spellname);
            return View("~/Views/Contact/mobilejoin.cshtml", model);
        }

        /// <summary>
        /// 下载页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Download()
        {          
            return View("~/Views/Mobile/Product/Download.cshtml");
        }
    }
}