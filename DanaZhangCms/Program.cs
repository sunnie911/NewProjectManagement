using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DanaZhangCms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseUrls("http://*:8618")
             .UseStartup<Startup>();
    }
}
