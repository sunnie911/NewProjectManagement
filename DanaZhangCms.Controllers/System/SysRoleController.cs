using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DanaZhangCms.Models;
using DanaZhangCms.IRepositories;
using System.Threading.Tasks;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Models;
using System.Linq;
using DanaZhangCms.Controllers.Filters;

namespace DanaZhangCms.Controllers
{
    [ControllerDescription(Name = "角色管理")]
    public class SysRoleController : SysBaseController
    {
        private ISysRoleRepository SysRoleRepository;

        public SysRoleController(ISysRoleRepository repository)
        {
            SysRoleRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Views

        [ActionDescription(Name = "角色列表")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        [AjaxRequestOnly, HttpGet]
        [ActionDescription(Name = "获取角色列表")]
        public Task<IActionResult> GetEntities()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var rows = SysRoleRepository.Get().ToList();
                return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        [AjaxRequestOnly]
        [ActionDescription(Name = "分页获取角色列表")]
        public Task<IActionResult> GetEntitiesByPaged(int pageSize, int pageIndex)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = SysRoleRepository.Count(m => true);
                var rows = SysRoleRepository.GetByPagination(m => true, pageSize, pageIndex, true,
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
        [ActionDescription(Name = "创建角色")]
        public Task<IActionResult> Add(SysRole model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                SysRoleRepository.AddAsync(model, false);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost]
        [ActionDescription(Name = "编辑")]
        public Task<IActionResult> Edit(SysRole model)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                SysRoleRepository.Edit(model, false);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxRequestOnly]
        [ActionDescription(Name = "删除")]
        public Task<IActionResult> Delete(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                SysRoleRepository.Delete(id, false);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }
    }
}