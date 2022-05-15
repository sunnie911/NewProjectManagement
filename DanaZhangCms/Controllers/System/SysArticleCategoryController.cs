 
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

namespace DanaZhangCms
{
    [ControllerDescription(Name = "新闻分类")]
    public class SysArticleCategoryController : BaseController
    {
        private IArticleCategoryRepository _repository;

        public SysArticleCategoryController(IArticleCategoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Views
        [ActionDescription(Name = "分类列表")]
        public IActionResult Index()
        {
            return View();
        }

        [Ignore]
        [ActionDescription(Name = "添加分类")]
        public IActionResult Create()
        {
            var model = new ArticleCategory();
            GetPosition();
            return View(model);
        }
        [Ignore]
        [ActionDescription(Name = "修改分类")]
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
            var articleCategory = _repository.Where(m => m.IsDeleted == false ).Include(o => o.ChildList).Where(c => c.Parent == null)
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


        [AjaxRequestOnly]
        [HttpGet, HttpPost]
        public Task<IActionResult> GetEntities()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var rows = _repository.Get().Select(o => new { o.Id, o.ParentId, o.Name,o.NameEn, pname = o.Parent == null ? "" : o.Parent.Name }).ToList();
                return Json(new { code = 0, tip = "操作成功！", msg = "", @is = true, count = rows.Count(), data = rows });
            });
        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int pageSize, int pageIndex)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _repository.Count(m => m.IsDeleted == false );
                var rows = _repository.GetByPagination(m => m.IsDeleted == false, pageSize, pageIndex, true,
                    m => m.Id).ToList();
                return Json(PaginationResult.PagedResult(rows, total, pageSize, pageIndex));
            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ValidateAntiForgeryToken]
        public Task<IActionResult> Add(ArticleCategory model)
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
        public Task<IActionResult> Edit(ArticleCategory model)
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
        [AjaxRequestOnly]
        public Task<IActionResult> Delete(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                //_repository.Delete(id, false);
                var model = _repository.GetSingle(id);
                model.IsDeleted = true;
                _repository.Edit(model, false);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        #endregion
    }
}