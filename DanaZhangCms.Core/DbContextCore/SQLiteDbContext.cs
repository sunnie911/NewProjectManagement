using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DanaZhangCms.Core.Options;

namespace DanaZhangCms.Core.DbContextCore
{
    public class SQLiteDbContext:BaseDbContext
    {
        public SQLiteDbContext(IOptions<DbContextOption> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_option.ConnectionString);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
