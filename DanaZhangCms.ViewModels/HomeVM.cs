using DanaZhangCms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanaZhangCms.ViewModels
{
   public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Article> Articles { get; set; }


        public List<Article> Cases { get; set; }

        public List<Article> Vedios { get; set; }

        public List<Banner> Banners { get; set; }

        public List<Article> Logos { get; set; }
    }
}
