using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PostWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker1>();
                    services.AddHostedService<Worker2>();
                    services.AddLogging(lb =>
                    {
                        lb.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                        lb.AddFile(o => o.RootPath = AppContext.BaseDirectory);
                    });
                });
    }
}
