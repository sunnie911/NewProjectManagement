using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DanaZhangCms.Core.Models;

namespace DanaZhangCms.Models
{
    [Table("SysUser"), Serializable]
    public class SysUser:BaseModel<int>
    {
        
        

        [Required]
        [MaxLength(20)]
        public string SysUserName { get; set; }

        [MaxLength(100)]
        public string EMail{get;set;}

        [MaxLength(20)]
        public string Telephone{get;set;}

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public bool Activable { get; set; } = true;


        public DateTime? LatestLoginDateTime{get;set;}

        [MaxLength(100)]
        public string LatestLoginIP{get;set;}
    }
}
