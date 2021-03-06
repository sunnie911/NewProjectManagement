 
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
    public class ProductController : BaseController
    {

        private IProductRepository _proRepository;

        private IContentsRepository _conRepository;

        public ProductController(IProductRepository proRepository, IContentsRepository contentRepository)
        {
            _proRepository = proRepository;
            _conRepository = contentRepository;
        }

        ///首页
        public IActionResult Index(int categoryId, string word)
        {

            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/product");
            }
            List<Product> productList = new List<Product>();

            if (categoryId > 0)
            {
            
                productList = _proRepository.Where(p => p.CategoryId == categoryId && p.IsDeleted == false).OrderByDescending(o => o.IsHot).OrderBy(o=>o.SortId).ToList();

            }
            else
            {
                productList = _proRepository.Where(p =>   p.IsDeleted == false).OrderByDescending(o => o.IsHot).OrderBy(o => o.SortId).ToList();

            }
            if (!string.IsNullOrWhiteSpace(word))
            {
                productList = _proRepository.Where(p => p.IsDeleted == false&&(p.Name.Contains(word)|| p.Model1.Contains(word))).OrderByDescending(o => o.IsHot).OrderBy(o => o.SortId).ToList();
            }


            return View(productList);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id)
        {

            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/proDetail/"+id);
            }
            var model = await _proRepository.GetSingleAsync(id);

            var contents = _conRepository.Where(p => p.ProductId == id&&p.IsDeleted==false).OrderBy(o => o.SortId).ToList();

            ProductView view = new ProductView() { Product=model };
            view.Details = contents.Where(p => p.Type == "规格参数" && p.SpellName == "china").ToList();
            view.DetailsEn = contents.Where(p => p.Type == "规格参数" && p.SpellName == "english").ToList();
            view.Downfiles= contents.Where(p => p.Type == "相关下载").ToList();

            ViewBag.SeoTitle = model.Name+"冠力科技";
            //ViewBag.SeoKeyword = site.SeoKeyword;
            //ViewBag.SeoDescription = site.SeoDescription;

            return View(view);
        }

        /// <summary>
        /// 售后服务
        /// </summary>
        /// <returns></returns>
        public IActionResult Service()
        {
            return View("~/Views/About/service.cshtml");
        }

        /// <summary>
        /// 下载页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Download()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/download");
            }
           
             
            return View("~/Views/Product/DownLoad.cshtml");
        }
    }
}