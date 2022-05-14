using System;
using System.Collections.Generic;
using System.Text;
using DanaZhangCms.Models;

namespace DanaZhangCms.ViewModels
{
  public   class ProductView
    {
        /// <summary>
        /// 产品
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 参数规格
        /// </summary>
        public List<Contents> Details { get; set; }
        /// <summary>
        /// 参数规格英文
        /// </summary>
        public List<Contents> DetailsEn { get; set; }
        /// <summary>
        /// 下载
        /// </summary>
        public List<Contents> Downfiles { get; set; }
    }
}
