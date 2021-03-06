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
    public class VedioController : BaseController
    {
      
        private IArticleRepository _artRepository;
        public VedioController(  IArticleRepository artRepository, IProductCategoryRepository pcateRepository)
        { 
            _artRepository = artRepository;
             
        }

        ///首页
        public IActionResult Index(int page = 1 )
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/vedio");
            }
            var arts = _artRepository.Where(o=>o.IsDeleted==false&&o.CategoryId==3).OrderBy(o => o.SortId).Select(o => new Article() { Title = o.Title, Id = o.Id, ImgUrl = o.ImgUrl,VedioUrl=o.VedioUrl,CreatedDate=o.CreatedDate,ClickCount=o.ClickCount,Content=o.Content }).ToList();
            var total = _artRepository.Where(o=>o.IsDeleted==false&&o.CategoryId==3).Count();
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
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/VedioDetail/"+id);
            }

            var model = await _artRepository.GetSingleAsync(id);
            return View(model);
        }
    }
}