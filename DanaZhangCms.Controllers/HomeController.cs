using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DanaZhangCms.Controllers
{
    [Ignore]
    public class HomeController : BaseController
    {
        private IProductRepository _proRepository;
        private IArticleRepository _artRepository;
        public HomeController(IProductRepository proRepository, IArticleRepository artRepository)
        {
            _proRepository = proRepository;
            _artRepository = artRepository;
        }

        ///首页
        public IActionResult Index()
        {

            var articleList = _artRepository.ToList();
            var model = new HomeVM();
            var pros = _proRepository.OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Take(8).Select(o => new Product() { Name = o.Name, Id = o.Id, ImgUrl = o.ImgUrl }).ToList();
            var arts = articleList.Where(a=>a.CategoryId==4).OrderByDescending(o => o.Id).Take(20).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();
            var vedios = articleList.Where(a => a.CategoryId == 3).OrderByDescending(o => o.Id).Take(20).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, CreatedDate = o.CreatedDate }).ToList();

            model.Products = pros;
            model.Articles = arts;
            model.Vedios = vedios;
            return View(model);
        }
    }
}