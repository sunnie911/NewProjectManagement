using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DanaZhangCms.Core.Options;

namespace DanaZhangCms.Core.DbContextCore
{
    public class InMemoryDbContext:BaseDbContext
    {
        public InMemoryDbContext(IOptions<DbContextOption> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase(_option.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
