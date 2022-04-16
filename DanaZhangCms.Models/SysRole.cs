using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DanaZhangCms.Core.Models;

namespace DanaZhangCms.Models
{
    [Table("SysRole")]
    public class SysRole : BaseModel<int>
    {
        
        

        [Required]
        [MaxLength(50)]
        public string SysRoleName{get;set;}

        public int ParentId{get;set;}

        public string NodePath{get;set;}

        public bool Activable{get;set;}=true;

   
    }
}
