using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DanaZhangCms.Core.IoC;
using DanaZhangCms.Core.Options;

namespace DanaZhangCms.Core.DbContextCore
{
    public class PostgreSQLDbContext:BaseDbContext
    {
        public PostgreSQLDbContext(IOptions<DbContextOption> option) : base(option)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_option.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
