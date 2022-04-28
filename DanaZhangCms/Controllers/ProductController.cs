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
        private IProductCategoryRepository _pcateRepository;
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        private IProductCategoryRepository _cateRepository;
        public ProductController(IProductCategoryRepository cateRepository,   IProductRepository proRepository, IArticleRepository artRepository, IProductCategoryRepository pcateRepository)
        {
            _cateRepository = cateRepository;
            _proRepository = proRepository;
            _artRepository = artRepository;
            _pcateRepository = pcateRepository;
        }

        ///首页
        public IActionResult Index(int page,  int categoryId, int pageSize = 10)
        {
            if (page == 0)
            {
                page = 1;
            }

            List<Product> productList = new List<Product>();
            var total = _proRepository.Count();
            if (categoryId > 0)
            {
                productList = _proRepository.Where(p=>p.CategoryId == categoryId).OrderBy(o => o.IsHot).Skip((page - 1) * pageSize).ToList();
                total = _proRepository.Where(p=>p.CategoryId==categoryId).Count();
            }
            else
            {
                productList = _proRepository.OrderBy(o => o.IsHot).Skip((page - 1) * pageSize).Take(pageSize).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl, IsHot = o.IsHot }).ToList();

            }   
            
            ViewBag.Total = total; 
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
            // var cateName =await _pcateRepository.GetSingleAsync(model.CategoryId);
            return View(model);
        }
    }
}