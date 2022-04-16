using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class SysRoleRepository : BaseRepository<SysRole, int>, ISysRoleRepository
    {
        public SysRoleRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}