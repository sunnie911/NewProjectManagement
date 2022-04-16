using DanaZhangCms.Core.Cache;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.IoC;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DanaZhangCms.Repositories
{
    public class SysMenuRepository : BaseRepository<SysMenu, int>, ISysMenuRepository
    {
        static SysMenuRepository()
        {
            TinyMapper.Bind<SysMenu, SysMenuViewModel>();
            //
            Triggers<SysMenu>.Inserted += AfterInserted;
            //
            Triggers<SysMenu>.Updating += WhileUpdating;
        }
        public SysMenuRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        public static void AfterInserted(IInsertedEntry<SysMenu, DbContext> entry)
        {
            using (var service = AspectCoreContainer.Resolve<ISysMenuRepository>())
            {
                if (entry.Entity.ParentId.HasValue)
                {
                    entry.Entity.MenuPath = entry.Entity.Id.ToString();

                    var parentMenu = service.GetSingle(entry.Entity.ParentId.Value);
                    entry.Entity.MenuPath = parentMenu.MenuPath + "," + entry.Entity.Id;
                }
                else
                {
                    //var parentMenu = service.GetSingle(entry.Entity.ParentId);
                    //if (string.IsNullOrEmpty(parentMenu?.MenuPath))
                    //{
                    entry.Entity.MenuPath = entry.Entity.Id.ToString();
                    //}
                    //else
                    //{

                    //}
                }
                service.Update(entry.Entity, false, "MenuPath");
                DistributedCacheManager.Remove("Redis_Cache_SysMenu");//
            }
        }

        public static void WhileUpdating(IUpdatingEntry<SysMenu, DbContext> entry)
        {
            using (var service = AspectCoreContainer.Resolve<ISysMenuRepository>())
            {
                if (entry.Entity.ParentId.HasValue)
                {
                    var parentMenu = service.GetSingle(entry.Entity.ParentId.Value);

                    entry.Entity.MenuPath = parentMenu.MenuPath + "," + entry.Entity.Id;

                }
                else
                {


                    entry.Entity.MenuPath = entry.Entity.Id.ToString();
                }

            }
        }
        public IList<SysMenuViewModel> GetHomeMenusByTreeView(Expression<Func<SysMenu, bool>> where)
        {
            return GetHomeTreeMenu(where);
        }
        public IList<SysMenuViewModel> GetMenusByTreeView(Expression<Func<SysMenu, bool>> @where)
        {
            return GetTreeMenu(where);
        }

        public IList<SysMenu> GetMenusByCache(Expression<Func<SysMenu, bool>> @where)
        {
            return DbContext.Get(where, true).ToList();
        }

        private IList<SysMenuViewModel> GetHomeTreeMenu(Expression<Func<SysMenu, bool>> where)
        {
            var reslut = new List<SysMenuViewModel>();
            var children = Get(where).OrderBy(m => m.SortId).ToList();
            foreach (var child in children)
            {
                var tmp = new SysMenuViewModel();
                tmp = TinyMapper.Map(child, tmp);
                tmp.RouteUrl = "/" + tmp.RouteUrl;
                //tmp.RouteUrl = ConfigHelper.GetConfigurationValue("appSettings:AdminDomain") + tmp.RouteUrl;
                tmp.Children = GetHomeTreeMenu(m => m.ParentId == tmp.Id && m.Activable && m.Visiable);
                reslut.Add(tmp);
            }
            return reslut;
        }
        private IList<SysMenuViewModel> GetTreeMenu(Expression<Func<SysMenu, bool>> where)
        {
            var reslut = new List<SysMenuViewModel>();
            var children = Get(where).OrderBy(m => m.SortId).ToList();
            foreach (var child in children)
            {
                var tmp = new SysMenuViewModel();
                tmp = TinyMapper.Map(child, tmp);
                tmp.Children = GetTreeMenu(m => m.ParentId == tmp.Id && m.Activable);
                reslut.Add(tmp);
            }
            return reslut;
        }
    }
}