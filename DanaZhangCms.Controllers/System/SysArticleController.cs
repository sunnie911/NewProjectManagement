using DanaZhangCms.Controllers.Filters;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms.Controllers
{
    [ControllerDescription(Name = "新闻")]
    public class SysArticleController : BaseController
    {
        private IArticleRepository _repository;
        private IArticleCategoryRepository _cateRepository;
        public SysArticleController(IArticleRepository repository, IArticleCategoryRepository cateRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cateRepository = cateRepository;
        }

        #region Views
        [ActionDescription(Name = "新闻列表")]
        public IActionResult Index()
        {
            GetPosition();
            return View();
        }
        [ActionDescription(Name = "添加新闻")]
        public IActionResult Create()
        {
            var model = new Article();
            GetPosition();
            return View(model);
        }
        [Ignore]
        [ActionDescription(Name = "编辑新闻")]
        public IActionResult Edit(int id)
        {
            GetPosition();
            return View("Create", _repository.GetSingle(id));
        }

        #endregion

        #region Methods
        [NonAction]
        private void GetPosition()
        {
            var position = new List<ArticleCategory>();
            var articleCategory = _cateRepository.Include(o => o.ChildList).Where(c => c.Parent == null)
                                 .ToList();
            if (articleCategory != null)
            {
                foreach (var item in articleCategory)
                {
                    position.Add(item);
                    if (item.ChildList.Any())
                    {
                        foreach (var citem in item.ChildList)
                        {
                            citem.Name = "    ----" + citem.Name;
                            position.Add(citem);
                        }
                    }
                }
            }

            ViewBag.CategoryList = position
                                        .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                                        .ToList();
        }

        [AjaxRequestOnly, HttpGet]
        public async Task<IActionResult> GetEntities()
        {

            var rows = await _repository.GetAsync();
            return Json(ExcutedResult.SuccessResult(rows));

        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int limit, int page, int CategoryId=0)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _repository.Count(m => true);

                Func<IQueryable<Article>, IQueryable<Article>> @include = o => o.Include("Category");
                var rows = _repository.GetByPaginationWithInclude(m => true, @include, limit, page, true,
                    m => m.Id).Select(o => new { o.Id, o.Title, o.Author, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"),CategoryId=o.CategoryId ,CateName = o.Category.Name }).ToList();
                if (CategoryId > 0)
                {
                      rows = _repository.GetByPaginationWithInclude(m => m.CategoryId==CategoryId, @include, limit, page, true,
                       m => m.Id).Select(o => new { o.Id, o.Title, o.Author, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), CategoryId = o.CategoryId, CateName = o.Category.Name }).ToList();
                }
                return Json(LayUIPaginationResult.PagedResult(true, rows, total));
            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ValidateAntiForgeryToken]
        public Task<IActionResult> Add(Article model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                _repository.AddAsync(model, false);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost]
        public Task<IActionResult> Edit(Article model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                _repository.Edit(model, false);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost]
        public Task<IActionResult> Delete(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                _repository.Delete(id, true);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        #endregion
    }
}