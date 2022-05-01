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
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            
            var arts = _artRepository.Where(o=>o.CategoryId==4).OrderByDescending(o => o.ClickCount).ThenByDescending(o => o.CreatedDate).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl,VedioUrl=o.VedioUrl,CreatedDate=o.CreatedDate,ClickCount=o.ClickCount,Content=o.Content }).ToList();
            var total = _artRepository.Where(o=>o.CategoryId==4).Count();
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