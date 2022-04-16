using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms.Controllers
{
    [Ignore]
    public class ProductController : BaseController
    {
        private IProductCategoryRepository _pcateRepository;
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        public ProductController(IProductRepository proRepository, IArticleRepository artRepository, IProductCategoryRepository pcateRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _pcateRepository = pcateRepository;
        }

        ///首页
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            var pros = _proRepository.OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Take(8).Skip((page - 1) * pageSize).Take(pageSize).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl }).ToList();
            var total = _proRepository.Count();
            ViewBag.Total = total;
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