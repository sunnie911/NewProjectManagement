using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DanaZhangCms.Core.Models;

namespace DanaZhangCms.Models
{
    [Table("Content"), Serializable]
    public class Contents : BaseModel<int>
    {
    
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }


        [Display(Name = "排序")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        [Range(0, 99999)]
        public int SortId { get; set; }


        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "简拼")]
        public string SpellName { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string Type { get; set; }
        [Display(Name = "文件名称")]
        public string FileName { get; set; }
        [Display(Name = "文件地址")]
        public string FilePath { get; set; }

    }
}