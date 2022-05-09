using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
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

        public ProductController(IProductRepository proRepository)
        {

            _proRepository = proRepository;

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
                //productList = _proRepository.Where(p=>p.CategoryId == categoryId).OrderBy(o => o.IsHot).Skip((page - 1) * pageSize).ToList();
                productList = _proRepository.Where(p => p.CategoryId == categoryId).OrderBy(o => o.IsHot).ToList();

            }
            else
            {
                productList = _proRepository.OrderBy(o => o.IsHot).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl, IsHot = o.IsHot }).ToList();

            }
            if (!string.IsNullOrWhiteSpace(word))
            {
                productList = _proRepository.Where(p => p.Name.Contains(word)|| p.Model1.Contains(word)).OrderBy(o => o.IsHot).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl, IsHot = o.IsHot }).ToList();
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
            var model = await _proRepository.GetSingleAsync(id);
            return View(model);
        }

        /// <summary>
        /// 售后服务
        /// </summary>
        /// <returns></returns>
        public IActionResult Service()
        {
            return View("~/Views/About/service.cshtml");
        }

    }
}