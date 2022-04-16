using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class ContentsRepository : BaseRepository<Contents, int>, IContentsRepository
    {
        public ContentsRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}