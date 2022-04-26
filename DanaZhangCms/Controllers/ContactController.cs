using DanaZhangCms.Core.Attributes;
using DanaZhangCms.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
namespace DanaZhangCms
{
    [Ignore]
    public class ContactController : BaseController
    {

        private IProductCategoryRepository _cateRepository;
        private IProductRepository _proRepository;
        private IContentsRepository _repository;
        public ContactController(IContentsRepository repository,IProductRepository proRepository, IProductCategoryRepository cateRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cateRepository = cateRepository;
            _proRepository = proRepository;
        }

        public  IActionResult Index(string spellname = "")
        {
            var position = _proRepository.ToList();
            ViewBag.ProductList = position;
            ViewBag.CategoryList = _cateRepository.ToList();
            var model =  _repository.FirstOrDefault(o => o.SpellName == spellname);
            return View(model);
        }


    }
}