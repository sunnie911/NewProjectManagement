﻿using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace  DanaZhangCms.Core
{
    public class LocalMediaService : IMediaService
    {
        private const string MediaRootFoler = "Uploads";

    
       

        public string SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
           var dateFoler=System.DateTime.Now.ToString("yyyy-MM-dd");
           var foler=Path.Combine(GlobalConfiguration.ContentPath, MediaRootFoler,dateFoler);
           if( !System.IO.Directory.Exists(foler)){
              System.IO.Directory.CreateDirectory(foler);
           }
            var filePath = Path.Combine(foler, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                mediaBinaryStream.CopyTo(output);
            }
            return $"/{MediaRootFoler}/{dateFoler}/{fileName}";
        }



    }
}