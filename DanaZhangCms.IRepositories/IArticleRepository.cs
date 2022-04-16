using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.Models;
using DanaZhangCms.ViewModels;

namespace DanaZhangCms.IRepositories
{
    public interface IArticleRepository : IRepository<Article, int>
    {
      
    }
}