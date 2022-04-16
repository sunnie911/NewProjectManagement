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
        /// 头图
        /// </summary>
        [Display(Name = "头图")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        [Display(Name = "排序")]
        public int SortId { get; set; }
    }
}
