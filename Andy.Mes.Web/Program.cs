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
                // ��ȡ��Ŀ����
                var env = hostcontext.HostingEnvironment;
                config.SetBasePath(env.ContentRootPath);
                //ָ����Ŀ�����ļ�  ����reloadOnChange��ʾ�����ļ������仯��ʱ����Ŀ�Զ����¼��ء�
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //ָ����Ŀ��ͬ������ʹ���ĸ������ļ���env.EnvironmentName��Ҫ�п�������Development�����ɻ���Production��������ָ�������������ļ��ǳ�����
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //���ö໷������
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });
    }
}
