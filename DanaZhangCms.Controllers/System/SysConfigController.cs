using DanaZhangCms.Controllers.Filters;
using DanaZhangCms.Core;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Helpers;
using DanaZhangCms.Core.Models;
using DanaZhangCms.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DanaZhangCms.Controllers
{
    [ControllerDescription(Name = "系统配置")]
    public class SysConfigController : SysBaseController
    {

        public SysConfigController(IContentsRepository repository)
        {

        }

        #region Views
        [ActionDescription(Name = "系统配置")]
        public IActionResult Index()
        {
            var filePath = System.IO.Path.Combine(GlobalConfiguration.ApplicationPath, "XmlConfig", "site.config");
            var site = XmlHelper.XmlDeserializeFromFile<SiteXml>(filePath, System.Text.Encoding.UTF8);
            return View(site);

        }
        #endregion

        #region Methods
        [AjaxRequestOnly, HttpPost]
        public IActionResult Index(SiteXml model)
        {
            var filePath = System.IO.Path.Combine(GlobalConfiguration.ApplicationPath, "XmlConfig", "site.config");
            XmlHelper.XmlSerializeToFile(model, filePath, System.Text.Encoding.UTF8);
            return Json(ExcutedResult.SuccessResult());
        }
        #endregion


    }
}