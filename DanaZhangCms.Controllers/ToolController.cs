using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Extensions;
using DanaZhangCms.Controllers.Filters;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.Core;
using System.IO;

namespace DanaZhangCms.Controllers
{
    [Ignore]
    public class ToolController:Controller
    {
          private IImageProcessor _repository;
          private IMediaService _mediaService;
        public ToolController(IImageProcessor repository,IMediaService mediaService)
        {
           _repository=repository;
           _mediaService=mediaService;
        }
        ///首页
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
              IFormFile file = Request.Form.Files[0];
              var url = SaveFile(file);
              return Json(new{uploaded=true,url=url});
        }
        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            var url= _mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);
            return url;
        }
    }
}