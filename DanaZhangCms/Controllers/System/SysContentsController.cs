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
        public IActionResult Create(int pId = 0, string lang = "china", string type = "0")
        {
            var model = new Contents() { ProductId = pId, SpellName = lang };
            if (type == "0")
            {
                model.Type = "规格参数";
            }
            else if (type == "1")
            {
                model.Type = "相关下载";
            }
            else
            {
                model.Type = type;
            }

            return View(model);
        }

        [ActionDescription(Name = "添加招人信息")]
        public IActionResult CreateNew(string spellName = "Recruit")
        {
            var model = new Contents() { SpellName= spellName };
       
            return View("~/Views/SysContents/CreateNew.cshtml", model);
        }
        [Ignore]
        [ActionDescription(Name = "编辑内容")]
        public IActionResult Edit(int id)
        {
            var model = _repository.GetSingle(id);
            if (model != null && model.SpellName.Contains("Recruit"))
            {
                return View("CreateNew", model);
            }

            return View("Create", _repository.GetSingle(id));
        }
        #endregion

        #region Methods

        [AjaxRequestOnly, HttpGet]
        public Task<IActionResult> GetEntities()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var rows = _repository.Get(p => p.IsDeleted == false && p.ProductId == 0).ToList();
                return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int limit, int page,string spellName="")
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _repository.Count(m => m.IsDeleted == false && m.ProductId == 0);



                var rows = _repository.GetByPagination(m =>m.IsDeleted==false&& m.ProductId == 0, limit, page, true,
                    m => m.Id).Select(o => new { o.Id, o.Title, o.SpellName, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd") }).ToList();

                if (!string.IsNullOrWhiteSpace(spellName))
                {
                    total = _repository.Count(m => m.IsDeleted == false && m.ProductId == 0 && m.SpellName.Contains(spellName));

                    rows = _repository.GetByPagination(m => m.IsDeleted == false && m.ProductId == 0&&m.SpellName.Contains(spellName), limit, page, true,
                     m => m.Id).Select(o => new { o.Id, o.Title, o.SpellName, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd") }).ToList();
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
        public Task<IActionResult> Add(Contents model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                model.IsDeleted = false;
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
                //if (!ModelState.IsValid)
                //    return Json(ExcutedResult.FailedResult("数据验证失败"));
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