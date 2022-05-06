using DanaZhangCms.Core.Attributes;
using DanaZhangCms.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
namespace DanaZhangCms
{
    [Ignore]
    public class AboutController : BaseController
    { 
        private IContentsRepository _repository;
        public AboutController(IContentsRepository repository )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 
        }

        public  IActionResult Index(string spellname = "")
        {
           
            var model =  _repository.FirstOrDefault(o => o.SpellName == spellname);
            return View(model);
        }


    }
}