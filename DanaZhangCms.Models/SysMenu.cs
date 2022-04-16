using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DanaZhangCms.Core.Models;

namespace DanaZhangCms.Models
{
    [Table("SysMenu")]
    public class SysMenu:BaseModel<int>
    {
        
        

        public int? ParentId { get; set; }

        [MaxLength(2000)]
        public string MenuPath { get; set; }

        [Required]
        [MaxLength(20)]
        public string MenuName { get; set; }

        [MaxLength(50)]
        public string MenuIcon { get; set; }

        [Required]
        [MaxLength(100)]
        public string Identity { get; set; }

        [Required]
        [MaxLength(200)]
        public string RouteUrl { get; set; }

        public bool Visiable { get; set; } = true;

        public bool Activable { get; set; } = true;

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SortId { get; set; }
    }
}
