using DanaZhangCms.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DanaZhangCms.Models
{
    [Table("Product")]
    public  class Product : BaseModel<int>
    {
        
        
        /// <summary>
        ///文章分类Id 
        /// </summary>
        [Required]
        [Display(Name = "分类")]
        public int CategoryId { get; set; }

        /// <summary>
        ///文章分类 
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Required]
        [Display(Name = "产品名称")]
        public string Name { get; set; }
        /// <summary>
        /// 头图
        /// </summary>
        [Display(Name = "头图")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        [Display(Name = "视频地址")]
        public string VedioUrl { get; set; } 
        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        public string Content { get; set; }

        /// <summary>
        /// 标签 已,分隔
        /// </summary>
        [Display(Name = "标签")]
        public string Tag { get; set; }


        /// <summary>
        /// 点击量
        /// </summary>
        [Display(Name = "点击量")]
        public int ClickCount { get; set; }

        /// <summary>
        /// 是否精选文章
        /// </summary>
        [Display(Name = "是否精选")]
        public bool IsHot { get; set; }


        /// <summary>
        /// 排序id
        /// </summary>
         [Display(Name = "排序")]
        public int SortId { get; set; }

    }
}
