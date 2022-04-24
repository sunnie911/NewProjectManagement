using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var pros = _proRepository.OrderBy(o=>o.IsHot).Take(10).Skip((page - 1) * pageSize).Take(pageSize).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl ,IsHot=o.IsHot}).ToList();
            var total = _proRepository.Count();
            ViewBag.Total = total;

            var position = _proRepository.ToList();
            ViewBag.ProductList = position;
            ViewBag.CategoryList = _cateRepository.ToList();
            return View(pros);
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