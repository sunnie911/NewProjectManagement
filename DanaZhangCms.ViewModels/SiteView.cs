using System;
using System.Collections.Generic;
using System.Text;

namespace DanaZhangCms.ViewModels
{
    public class SiteView
    {
        /// <summary>
        /// 文章总数
        /// </summary>
        public int Articles { get; set; }
        /// <summary>
        /// 视频数
        /// </summary>
        public int Vedios { get; set; }
       /// <summary>
       /// 产品数
       /// </summary>
        public int Products { get; set; }
        /// <summary>
        /// 合作机构数
        /// </summary>
        public int Logos { get; set; }

    }
}
