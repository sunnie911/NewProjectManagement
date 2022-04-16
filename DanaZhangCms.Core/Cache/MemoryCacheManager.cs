using Microsoft.Extensions.Caching.Memory;
using DanaZhangCms.Core.IoC;

namespace DanaZhangCms.Core.Cache
{
    public class MemoryCacheManager
    {
        public static IMemoryCache GetInstance() => AspectCoreContainer.Resolve<IMemoryCache>();
    }
}
