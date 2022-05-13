 
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
    [ControllerDescription(Name = "产品管理")]
    public class SysProductController : SysBaseController
    {
        private IContentsRepository _contentRepository;
        private IProductRepository _repository;
        private IProductCategoryRepository _cateRepository;
        public SysProductController(IProductRepository repository, IProductCategoryRepository cateRepository,IContentsRepository ContentRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cateRepository = cateRepository;
            _contentRepository = ContentRepository;
        }

        #region Views
        [ActionDescription(Name = "产品列表")]
        public IActionResult Index()
        {
            GetPosition();
            return View();
        }

        [Ignore]
        [ActionDescription(Name = "添加")]
        public IActionResult Create()
        {
            var model = new Product();
            GetPosition();
            return View(model);
        }
        [Ignore]
        [ActionDescription(Name = "修改")]
        public IActionResult Edit(int id)
        {
            GetPosition();
            return View("Create", _repository.GetSingle(id));
        }
        #endregion

        #region Methods
        private void GetPosition()
        {
            var position = new List<ProductCategory>();
            var category = _cateRepository.Include(o => o.ChildList).Where(c => c.Parent == null)
                                 .ToList();
            if (category != null)
            {
                foreach (var item in category)
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
        public Task<IActionResult> GetEntities()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var rows = _repository.Get().ToList();
                return Json(ExcutedResult.SuccessResult(rows));
            });
        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByPaged(int limit, int page, int CategoryId = 0,string title="")
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _repository.Count(m => true);
                //var rows = _repository.GetByPagination(m => true, limit, page, true,
                //   m => m.Id).ToList();
                // return Json(PaginationResult.PagedResult(rows, total, pageSize, pageIndex));
                Func<IQueryable<Product>, IQueryable<Product>> @include = o => o.Include("Category");
                var rows = _repository.GetByPaginationWithInclude(m => true, @include, limit, page, true,
              m => m.Id).Select(o => new { o.Id, o.Name,o.NameEn,o.ContentEn,o.Model1, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), CateName = o.Category == null ? "" : o.Category.Name }).ToList();

                if (CategoryId > 0)
                {
                      rows = _repository.GetByPaginationWithInclude(m => m.CategoryId==CategoryId, @include, limit, page, true,
             m => m.Id).Select(o => new { o.Id, o.Name, o.NameEn, o.ContentEn, o.Model1, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), CateName = o.Category == null ? "" : o.Category.Name }).ToList();

                }
                if (!string.IsNullOrWhiteSpace(title))
                {
                    rows = _repository.GetByPaginationWithInclude(m => m.Name.Contains(title.Trim()), @include, limit, page, true,
              m => m.Id).Select(o => new { o.Id, o.Name, o.NameEn, o.ContentEn, o.Model1, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), CateName = o.Category == null ? "" : o.Category.Name }).ToList();

                }

                return Json(LayUIPaginationResult.PagedResult(true, rows, total));
            });
        }

        [AjaxRequestOnly]
        public Task<IActionResult> GetEntitiesByProductId(int limit, int page,int pId=0)
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var total = _contentRepository.Where(p => p.ProductId==pId).Count(m => true);
                var rows = _contentRepository.GetByPagination(m =>m.ProductId==pId, limit, page, true,
                    m => m.Id).Select(o => new { o.Id, o.Title, o.SpellName,o.Type, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd") }).ToList();
                return Json(LayUIPaginationResult.PagedResult(true, rows, total));
            });
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxRequestOnly, HttpPost, ValidateAntiForgeryToken]
        public Task<IActionResult> Add(Product model)
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
        public Task<IActionResult> Edit(Product model)
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