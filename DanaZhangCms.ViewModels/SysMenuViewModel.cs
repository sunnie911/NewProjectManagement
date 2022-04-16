using System.Collections.Generic;
using DanaZhangCms.Models;

namespace DanaZhangCms.ViewModels
{
    public class SysMenuViewModel : SysMenu
    {
        public IList<SysMenuViewModel> Children { get; set; } = new List<SysMenuViewModel>();
    }
}
