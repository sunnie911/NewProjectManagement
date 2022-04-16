using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class BannerRepository : BaseRepository<Banner, Int32>, IBannerRepository
    {
        public BannerRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}