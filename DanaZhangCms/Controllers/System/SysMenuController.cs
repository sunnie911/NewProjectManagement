using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.Core.Models;
 
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;

namespace DanaZhangCms
{
    [ControllerDescription(Name = "菜单管理")]
    public class SysMenuController : SysBaseController
    {
        private ISysMenuRepository menuRepository;

        public SysMenuController(ISysMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
        }

        #region Views
        [ActionDescription(Name = "菜单列表")]
        public IActionResult Index()
        {
            return View();
        }
        [ActionDescription(Name = "新建菜单")]
        public IActionResult Create()
        {
            return View();
        }
        [ActionDescription(Name = "编辑菜单")]
        public IActionResult Edit(int id)
        {
            return View(menuRepository.GetSingle(id));
        }

        #endregion

        #region Methods

        [AjaxRequestOnly, HttpGet, ActionDescription(Description = "Ajax获取菜单列表", Name = "获取菜单列表")]
        public Task<IActionResult> GetMenus()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var rows = menuRepository.GetHomeMenusByTreeView(m => m.Activable && m.Visiable && m.ParentId ==null).OrderBy(m => m.SortId).ToList();
                return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        [AjaxRequestOnly, HttpGet, ActionDescription(Name = "获取菜单树", Description = "Ajax获取菜单树")]
        public Task<IActionResult> GetTreeMenus(int? parentId)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var nodes = menuRepository.GetMenusByTreeView(m => m.Activable &&  m.ParentId != null)
                    .OrderBy(m => m.SortId).Select(m => GetTreeMenus(m, parentId)).ToList();
                var rows = new[]
                {
                    new
                    {
                        text = " 根节点",
                        icon = "fas fa-boxes",
                        tags = "0",
                        nodes,
                        state = new
                        {
                            selected = parentId.HasValue
                        }
                    }
                };
                return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        private object GetTreeMenus(SysMenuViewModel viewModel, int? parentId)
        {
            if (viewModel.Children.Any())
            {
                return new
                {
                    text = " " + viewModel.MenuName,
                    icon = viewModel.MenuIcon,
                    tags = viewModel.Id.ToString(),
                    nodes = viewModel.Children.Select(x => GetTreeMenus(x, parentId)),
                    state = new
                    {
                        expanded = false,
                        selected = viewModel.Id == parentId
                    }
                };
            }
            return new
            {
                text = " " + viewModel.MenuName,
                icon = viewModel.MenuIcon,
                tags = viewModel.Id.ToString(),
                state = new
                {
                    selected = viewModel.Id == parentId
                }
            };
        }

        [AjaxRequestOnly, HttpGet, ActionDescription(Name = "获取菜单列表", Description = "Ajax分页获取菜单列表")]
        public Task<IActionResult> GetMenusByPaged(int pageSize, int pageIndex, string keyword)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                Expression<Func<SysMenu, bool>> filter = m => true;
                if (!string.IsNullOrEmpty(keyword))
                    filter = filter.And(m => m.Identity.Contains(keyword));
                var total = menuRepository.CountAsync(filter).Result;
                var rows = menuRepository.GetByPagination(filter, pageSize, pageIndex, true,
                    m => m.Id).ToList();
                return Json(PaginationResult.PagedResult(rows, total, pageSize, pageIndex));
            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ValidateAntiForgeryToken, ActionDescription(Name = "新建菜单", Description = "Ajax新建菜单")]
        public Task<IActionResult> Add(SysMenu menu)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                menuRepository.AddAsync(menu, true);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ActionDescription(Name = "编辑菜单", Description = "Ajax编辑菜单")]
        public Task<IActionResult> Edit(SysMenu menu)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                if (!ModelState.IsValid)
                    return Json(ExcutedResult.FailedResult("数据验证失败"));
                menuRepository.Edit(menu, true);
                return Json(ExcutedResult.SuccessResult());
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxRequestOnly, ActionDescription(Name = "删除菜单", Description = "Ajax删除菜单")]
        public Task<IActionResult> Delete(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                menuRepository.Delete(id);
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        /// <summary>
        /// 启停用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxRequestOnly, ActionDescription(Name = "启/停用菜单")]
        public Task<IActionResult> Active(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var entity = menuRepository.GetSingle(id);
                entity.Activable = !entity.Activable;
                menuRepository.Update(entity, false, "Activable");
                return Json(ExcutedResult.SuccessResult(entity.Activable ? "OK，已成功启用。" : "OK，已成功停用"));
            });
        }
        /// <summary>
        /// 是否在左侧菜单栏显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxRequestOnly, ActionDescription(Name = "显示/隐藏菜单")]
        public Task<IActionResult> Visualize(int id)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var entity = menuRepository.GetSingle(id);
                entity.Visiable = !entity.Visiable;
                menuRepository.Update(entity, false, "Visiable");
                return Json(ExcutedResult.SuccessResult("操作成功，请刷新当前网页或者重新进入系统。"));
            });
        }

        #endregion
    }
}