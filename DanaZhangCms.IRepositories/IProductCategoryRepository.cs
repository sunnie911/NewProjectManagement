using System;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.IRepositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory, int>
    {
    }
}