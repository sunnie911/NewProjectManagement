using DanaZhangCms.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DanaZhangCms.Models
{
    [Table("ProductCategory")]
    public class ProductCategory : BaseModel<int>
    {
        
        
        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [Display(Name = "分类名称")]
        public string Name { get; set; }
        /// <summary>
        /// 分类英文名称
        /// </summary>
        [Required]
        [Display(Name = "分类英文名称")]
        public string NameEn { get; set; }
        /// <summary>
        /// 父分类id
        /// </summary>
        [Display(Name = "父分类id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 父分类
        /// </summary>
        public virtual ProductCategory Parent { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }

        [Display(Name = "排序")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        [Range(0, 99999)]
        public int SortId { get; set; }


  
        [Display(Name = "SEO标题")]
        public string Title { get; set; }

        [Display(Name = "SEO关键字")]
        public string KeyWord { get; set; }

        [Display(Name = "SEO描述")]
        public string Description { get; set; }

        public virtual ICollection<ProductCategory> ChildList { get; set; }

    }
}
