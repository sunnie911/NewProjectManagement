using DanaZhangCms.Controllers.Filters;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms.Controllers
{
    [ControllerDescription(Name = "用户管理")]
    public class SysUserController : SysBaseController
    {
        private ISysUserRepository _repository;

        public SysUserController(ISysUserRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #region Views
        [ActionDescription(Name = "用户列表")]
        public IActionResult Index()
        {
            return View();
        }
        [Ignore]
        [ActionDescription(Name = "修改密码")]
        public IActionResult EditPwd(int id)
        {
            var model = _repository.GetSingle(id);
            model.Password = "";
            return View(model);
        }
        #endregion

        #region Methods

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int limit, int page)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _repository.Count(m => true);
                var rows = _repository.GetByPagination(m => true, limit, page, true,
                    m => m.Id).Select(o => new { o.Id, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), o.SysUserName, o.Telephone }).ToList();
                return Json(LayUIPaginationResult.PagedResult(true, rows, total));
            });
        }
        [Ignore]
        [AjaxRequestOnly, HttpPost]
        public IActionResult EditPwd(SysUser model)
        {
            _repository.ChangePassword(model.Id, model.Password);
            return Json(ExcutedResult.SuccessResult());
        }
        #endregion
    }
}