using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms
{
    [Ignore]
    public class ArticleController : BaseController
    {
        private IArticleRepository _artRepository;
        public ArticleController( IArticleRepository artRepository )
        {
        
            _artRepository = artRepository;
             
        }

        ///首页
        public IActionResult Index(int categoryId=4)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/article");
            }
            var arts = _artRepository.Where(o=>o.CategoryId== categoryId).OrderBy(o => o.SortId).ThenByDescending(o => o.CreatedDate).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl,VedioUrl=o.VedioUrl,CreatedDate=o.CreatedDate,ClickCount=o.ClickCount,Content=o.Content }).ToList();
            var total = _artRepository.Where(o=>o.CategoryId== categoryId).Count();
            ViewBag.Total = total;

            ViewBag.CategoryId = categoryId;

            var name = "学术交流";

            if (categoryId == 7)
            {
                name = "科研标准";
            }

            if (categoryId == 8)
            {
                name = "工程案例";
            }
            ViewBag.CategoryName = name;
            return View(arts);
        }

        ///首页
        public IActionResult Scient(int categoryId = 7)
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/article");
            }
            var arts = _artRepository.Where(o => o.CategoryId == categoryId).OrderBy(o => o.SortId).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl, VedioUrl = o.VedioUrl, CreatedDate = o.CreatedDate, ClickCount = o.ClickCount, Content = o.Content }).ToList();
            var total = _artRepository.Where(o => o.CategoryId == categoryId).Count();
            ViewBag.Total = total;

            ViewBag.CategoryId = categoryId;

            var name = "学术交流";

            if (categoryId == 7)
            {
                name = "科研标准";
            }
            ViewBag.CategoryName = name;
            return View("~/Views/Article/index.cshtml", arts);
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
                return Redirect("/mobile/newDetail/"+id);
            }

            var model = await _artRepository.GetSingleAsync(id);

            var preArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId&&p.SortId>model.SortId).OrderBy(o => o.SortId).Skip(1).ToList(); 
            var LastArticle = _artRepository.Where(p => p.CategoryId == model.CategoryId && p.SortId < model.SortId).OrderBy(o => o.SortId).Skip(1).ToList();

            if (preArticle != null && preArticle.Count > 0)
            {
                ViewBag.PreArticle = preArticle[0];
            }

            if (LastArticle != null && LastArticle.Count > 0)
            {
                ViewBag.LastArticle = LastArticle[0];
            }
            return View(model);
        }
    }
}