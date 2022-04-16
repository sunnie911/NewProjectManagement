using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, int>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}