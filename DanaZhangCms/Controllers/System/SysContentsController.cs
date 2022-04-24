using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DanaZhangCms.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Core.Attributes;
using System.Threading.Tasks;
using DanaZhangCms.Core.Models;
using System.Linq;
 

namespace DanaZhangCms
{
    [ControllerDescription(Name = "内容管理")]
    public class SysContentsController : SysBaseController
    {
        private IContentsRepository _repository;
        
        public SysContentsController(IContentsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Views

        [ActionDescription(Name = "内容列表")]
        public IActionResult Index()
        {
            return View();
        }
        [ActionDescription(Name = "添加内容")]
        public IActionResult Create()
        {
            var model = new Contents();
            return View(model);
        }
        [Ignore]
        [ActionDescription(Name = "编辑内容")]
        public IActionResult Edit(int id)
        {
            return View("Create", _repository.GetSingle(id));
        }
        #endregion

        #region Methods

        [AjaxRequestOnly, HttpGet]
        public Task<IActionResult> GetEntities()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                    var rows = _repository.Get().ToList();
                    return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int limit, int page)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                //var total = _repository.Count(m => true);
                //var rows = _repository.GetByPagination(m => true, pageSize, pageIndex, true,
                //    m => m.Id).ToList();
                //return Json(PaginationResult.PagedResult(rows, total, pageSize, pageIndex));
                var total = _repository.Count(m => true);
           
                var rows = _repository.GetByPagination(m => true, limit, page, true,
                    m => m.Id).Select(o => new { o.Id, o.Title, o.SpellName, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd") }).ToList();
                return Json(LayUIPaginationResult.PagedResult(true, rows, total));
            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly,HttpPost,ValidateAntiForgeryToken]
        public Task<IActionResult> Add(Contents model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if(!ModelState.IsValid)
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
        public Task<IActionResult> Edit(Contents model)
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
                _repository.Delete(id, false);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        #endregion
	}
}