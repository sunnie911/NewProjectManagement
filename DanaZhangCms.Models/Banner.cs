using DanaZhangCms.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DanaZhangCms.Models
{
    [Table("Banner")]
    public class Banner : BaseModel<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Required]
        [Display(Name = "英文名称")]
        public string NameEn { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        [Required]
        [Display(Name = "描述")]
        public string Summary { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        [Required]
        [Display(Name = "描述英文")]
        public string SummaryEn { get; set; }
        /// <summary>
        /// 头图
        /// </summary>
        [Display(Name = "头图")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        [Display(Name = "跳转链接")]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 英文跳转链接
        /// </summary>
        [Display(Name = "英文跳转链接")]
        public string LinkUrlEn { get; set; }
        /// <summary>
        /// 排序id
        /// </summary>
        [Display(Name = "排序")]
        public int SortId { get; set; }
    }
}
