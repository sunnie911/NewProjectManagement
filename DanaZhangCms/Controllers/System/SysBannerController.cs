 
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms
{
    [ControllerDescription(Name = "幻灯片")]
    public class SysBannerController : SysBaseController
    {
        private IBannerRepository _repository;

        public SysBannerController(IBannerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Views

        [ActionDescription(Name = "幻灯片列表")]
        public IActionResult Index()
        {
            return View();
        }

        [Ignore]
        [ActionDescription(Name = "幻灯片分类")]
        public IActionResult Create()
        {
            var model = new Banner();
            return View(model);
        }
        [Ignore]
        [ActionDescription(Name = "幻灯片分类")]
        public IActionResult Edit(int id)
        {
            var model = _repository.GetSingle(id);
            return View("Create", model);
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
                var total = _repository.Count(m => true);
                var rows = _repository.GetByPagination(m => true, limit, page, true, m => m.Id).ToList();
                return Json(LayUIPaginationResult.PagedResult(true, rows, total));

            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ValidateAntiForgeryToken]
        public Task<IActionResult> Add(Banner model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                //if (!ModelState.IsValid)
                //    return Json(ExcutedResult.FailedResult("数据验证失败"));
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
        public Task<IActionResult> Edit(Banner model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            { 
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
                _repository.Delete(id, true);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        #endregion
    }
}