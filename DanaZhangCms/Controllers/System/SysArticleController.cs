
using DanaZhangCms.Core;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms
{
    [ControllerDescription(Name = "新闻")]
    public class SysArticleController : BaseController
    {
        private IArticleRepository _repository;
        private IArticleCategoryRepository _cateRepository;

        private IArticleRepository _ArticleRepository;
        private IArticleCategoryRepository _ArticleCategoryRepository;
        private IProductCategoryRepository _ProductCateRepository;
        private IProductRepository _ProductRepository;
        public SysArticleController(IArticleRepository repository, IArticleCategoryRepository cateRepository, IProductCategoryRepository productCateRepository, IProductRepository productRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cateRepository = cateRepository;

            _ProductRepository = productRepository;
            _ProductCateRepository = productCateRepository ?? throw new ArgumentNullException(nameof(productCateRepository));
            _ArticleRepository = repository;
            _ArticleCategoryRepository = cateRepository;

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
            var articleCategory = _cateRepository.Where(c=>c.IsDeleted==false).Include(o => o.ChildList).Where(c => c.Parent == null)
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
                var rows = _repository.GetByPaginationWithInclude(m => m.IsDeleted==false, @include, limit, page, true,
                    m => m.SortId).Select(o => new { o.Id, o.Title, o.Author, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"),CategoryId=o.CategoryId ,CateName = o.Category.Name }).ToList();
                if (CategoryId > 0)
                {
                      rows = _repository.GetByPaginationWithInclude(m => m.IsDeleted == false&&m.CategoryId==CategoryId, @include, limit, page, true,
                       m => m.SortId).Select(o => new { o.Id, o.Title, o.Author, CreatedDate = o.CreatedDate.ToString("yyyy-MM-dd"), CategoryId = o.CategoryId, CateName = o.Category.Name }).ToList();
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

                createXMLSitemap();
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
                //_repository.Delete(id, true);
                var model = _repository.GetSingle(id);
                model.IsDeleted = true;
                _repository.Edit(model, false);
                createXMLSitemap();
                return Json(ExcutedResult.SuccessResult("成功删除一条数据。"));
            });
        }

        #endregion


        #region 网站地图
        public void createXMLSitemap()
        {
            FileInfo XMLFile = null;
            StreamWriter WriteXMLFile = null;
            var filePath = System.IO.Path.Combine(GlobalConfiguration.ApplicationPath, "sitemap.xml");
            XMLFile = new FileInfo(filePath);
            WriteXMLFile = XMLFile.CreateText();
            //下面两句话必须写，而且不能做任何修改
            WriteXMLFile.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            WriteXMLFile.WriteLine("<urlset xmlns=\"http://www.google.com/schemas/sitemap/0.84\">");

           

            getXMLSitemapData(WriteXMLFile);
            WriteXMLFile.WriteLine("</urlset>");//别忘了这句话
            WriteXMLFile.Close();
        }

        public void getXMLSitemapData(StreamWriter writerFile)
        {

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>1</priority>");
            writerFile.WriteLine("</url>");


            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>1</priority>");
            writerFile.WriteLine("</url>");
            var productCategory = _ProductCateRepository.Where(c => c.Parent == null && c.IsDeleted == false).ToList();
            //处理大类信息，
            if (productCategory != null && productCategory.Any())
            {
                foreach (var item in productCategory)
                {
                    writerFile.WriteLine("<url>");
                    writerFile.WriteLine("<loc>" + "https://jyhc17.com/Product?categoryId=" + item.Id + "</loc>");
                    writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                    writerFile.WriteLine("<changefreq>Always</changefreq>");
                    writerFile.WriteLine("<priority>0.9</priority>");
                    writerFile.WriteLine("</url>");

                    var productList = _ProductRepository.Where(p => p.CategoryId == item.Id).OrderByDescending(o => o.IsHot).ToList();
                    foreach (var pro in productList)
                    {
                        writerFile.WriteLine("<url>");
                        writerFile.WriteLine("<loc>" + "https://jyhc17.com/products/" + item.Id + ".html</loc>");
                        writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                        writerFile.WriteLine("<changefreq>Always</changefreq>");
                        writerFile.WriteLine("<priority>0.9</priority>");
                        writerFile.WriteLine("</url>");
                    }

                }
                foreach (var item in productCategory)
                {
                    writerFile.WriteLine("<url>");
                    writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/Product?categoryId=" + item.Id + "</loc>");
                    writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                    writerFile.WriteLine("<changefreq>Always</changefreq>");
                    writerFile.WriteLine("<priority>0.9</priority>");
                    writerFile.WriteLine("</url>");

                    var productList = _ProductRepository.Where(p => p.CategoryId == item.Id).OrderByDescending(o => o.IsHot).ToList();
                    foreach (var pro in productList)
                    {
                        writerFile.WriteLine("<url>");
                        writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/products/" + item.Id + ".html</loc>");
                        writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                        writerFile.WriteLine("<changefreq>Always</changefreq>");
                        writerFile.WriteLine("<priority>0.9</priority>");
                        writerFile.WriteLine("</url>");
                    }
                }

            }

            #region 公司简介

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/contact</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/contact</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/product/download</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/download</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/vedio</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/vedio</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/article</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            writerFile.WriteLine("<url>");
            writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/article</loc>");
            writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
            writerFile.WriteLine("<changefreq>Always</changefreq>");
            writerFile.WriteLine("<priority>0.8</priority>");
            writerFile.WriteLine("</url>");

            #endregion

            var articleCategory = _ArticleCategoryRepository.Where(c => c.IsDeleted == false && c.Id != 5).ToList();
            foreach (var cate in articleCategory)
            {
                var articleList = _ArticleRepository.Where(p => p.CategoryId == cate.Id).OrderByDescending(o => o.IsHot).ToList();
                foreach (var pro in articleList)
                {
                    writerFile.WriteLine("<url>");
                    writerFile.WriteLine("<loc>" + "https://jyhc17.com/news/" + pro.Id + ".html</loc>");
                    writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                    writerFile.WriteLine("<changefreq>Always</changefreq>");
                    writerFile.WriteLine("<priority>0.8</priority>");
                    writerFile.WriteLine("</url>");

                    writerFile.WriteLine("<url>");
                    writerFile.WriteLine("<loc>" + "https://jyhc17.com/english/news/" + pro.Id + ".html</loc>");
                    writerFile.WriteLine("<lastmod>" + DateTime.Now.ToShortDateString() + "</lastmod>");
                    writerFile.WriteLine("<changefreq>Always</changefreq>");
                    writerFile.WriteLine("<priority>0.8</priority>");
                    writerFile.WriteLine("</url>");
                }
            }



        }

        #endregion
    }
}