using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory, int>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}