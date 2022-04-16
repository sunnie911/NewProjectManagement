using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms.Core
{
    public interface IMediaService
    {      
        string SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null); 

    }
}