using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;

namespace DanaZhangCms.IRepositories
{
    public interface ISysMenuRepository:IRepository<SysMenu, int>
    {
        IList<SysMenuViewModel> GetHomeMenusByTreeView(Expression<Func<SysMenu, bool>> where);
        IList<SysMenuViewModel> GetMenusByTreeView(Expression<Func<SysMenu, bool>> where);

        [RedisCache(CacheKey = "Redis_Cache_SysMenu", Expiration = 5)]
        IList<SysMenu> GetMenusByCache(Expression<Func<SysMenu, bool>> where);
    }
}