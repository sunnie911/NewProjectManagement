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
    public class ArticleController : BaseController
    {
        private IProductCategoryRepository _pcateRepository;
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        public ArticleController(IProductRepository proRepository, IArticleRepository artRepository, IProductCategoryRepository pcateRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
            _pcateRepository = pcateRepository;
        }

        ///首页
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            
            var arts = _artRepository.Where(o=>o.IsDeleted==false).OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl,CreatedDate=o.CreatedDate,ClickCount=o.ClickCount,Content=o.Content }).ToList();
            var total = _artRepository.Count();
            ViewBag.Total = total;
            return View(arts);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _artRepository.GetSingleAsync(id);
            return View(model);
        }
    }
}