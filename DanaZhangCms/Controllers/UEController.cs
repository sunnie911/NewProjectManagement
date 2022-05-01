using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEditor.Core;

namespace CompanyCms.Controllers
{
    public class UEditorController : Controller
    {
        private readonly UEditorService _ueditorService;
        public UEditorController(UEditorService uEditorService) {
            this._ueditorService = uEditorService;
        }
        [HttpGet,HttpPost]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result,response.ContentType);
        }

       
    }
}
