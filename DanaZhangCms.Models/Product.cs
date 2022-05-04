using DanaZhangCms.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DanaZhangCms.Models
{
    [Table("Product")]
    public class Product : BaseModel<int>
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
        /// 产品英文名称
        /// </summary>

        [Display(Name = "产品英文名称")]
        public string NameEn { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [Display(Name = "型号")]
        public string Model { get; set; }
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
        [Display(Name = "产品细节")]
        public string Content { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "产品细节英文")]
        public string ContentEn { get; set; }
        /// <summary>
        /// 技术参数
        /// </summary>
        [Display(Name = "技术参数")]
        public string Paramter { get; set; }

        /// <summary>
        /// 产品细节英文
        /// </summary>
        [Display(Name = "产品细节英文")]
        public string ParamterEn { get; set; }



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
        /// 是否热卖
        /// </summary>
        [Display(Name = "是否热卖")]
        public bool IsHot { get; set; }


        /// <summary>
        /// 排序id
        /// </summary>
        [Display(Name = "排序")]
        public int SortId { get; set; }

        /// <summary>
        /// 轮播图
        /// </summary>
        [Display(Name = "轮播图1")]
        public string Banner1 { get; set; }
        /// <summary>
        /// 轮播图
        /// </summary>
        [Display(Name = "轮播图2")]
        public string Banner2 { get; set; }
        /// <summary>
        /// 轮播图
        /// </summary>
        [Display(Name = "轮播图3")]
        public string Banner3 { get; set; }
        /// <summary>
        /// 轮播图
        /// </summary>
        [Display(Name = "轮播图4")]
        public string Banner4 { get; set; }
       

    }
}
