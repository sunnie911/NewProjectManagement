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

 
        private IContentsRepository _repository;
        public ContactController(IContentsRepository repository )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
         
        }

        public  IActionResult Index()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/contact");
            }

            var model =  _repository.Where(o => o.ProductId==0 &&(o.SpellName.Contains("SeekArea")||o.SpellName.Contains("Contact")) && o.IsDeleted == false);
            return View(model);
        }

        public IActionResult Join()
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/join");
            }

            var model = _repository.Where(o =>(o.SpellName.Contains("Recruit")) && o.IsDeleted == false);
          
            return View("~/Views/Contact/join.cshtml", model);
        }
    }
}