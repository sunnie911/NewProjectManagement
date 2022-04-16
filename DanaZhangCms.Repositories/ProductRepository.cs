using System;
using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}