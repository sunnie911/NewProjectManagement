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

        public  IActionResult Index(string spellname = "")
        {
            if (RequestExtensions.IsMobile(HttpContext.Request))
            {
                return Redirect("/mobile/contact");
            }

            var model =  _repository.FirstOrDefault(o => o.SpellName == spellname);
            return View(model);
        }


    }
}