using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class ArticleRepository : BaseRepository<Article, int>, IArticleRepository
    {
        public ArticleRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}