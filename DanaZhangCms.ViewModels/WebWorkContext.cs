using DanaZhangCms.Core.Models;
using DanaZhangCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanaZhangCms.ViewModels
{
    public class WebWorkContext
    {
        public SiteXml Sites { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Contents> Content { get; set; }
    }
}
