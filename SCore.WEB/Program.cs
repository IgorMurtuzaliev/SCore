using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SCore.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
