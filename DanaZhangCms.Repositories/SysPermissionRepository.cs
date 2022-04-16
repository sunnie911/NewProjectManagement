using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class SysPermissionRepository : BaseRepository<SysPermission, int>, ISysPermissionRepository
    {
        public SysPermissionRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}