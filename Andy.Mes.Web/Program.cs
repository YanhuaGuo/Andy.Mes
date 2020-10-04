using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Andy.Mes.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog(dispose:true)
            .ConfigureAppConfiguration((hostcontext, config) =>
            {
                // 获取项目环境
                var env = hostcontext.HostingEnvironment;
                config.SetBasePath(env.ContentRootPath);
                //指定项目配置文件  属性reloadOnChange表示配置文件发生变化的时候，项目自动重新加载。
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //指定项目不同环境下使用哪个配置文件（env.EnvironmentName主要有开发环境Development和生成环境Production），对于指定环境的配置文件非常有用
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //启用多环境配置
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });
    }
}
