using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Andy.Mes.Application;
using Andy.Mes.Core;
using Andy.Mes.Core.Configuration;
using Andy.Mes.Web.Models;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Andy.Mes.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddHttpContextAccessor();
            services.AddControllers()
                .AddControllersAsServices();

            services.AddMvcCore(mvcOption =>
            {
                mvcOption.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(router =>
            {
                router.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                router.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //config
            SystemConfig config = new SystemConfig(); 
            Configuration.GetSection(SystemConfig.Position).Bind(config);
            SystemConfig.Config = config;

            //regist service
            builder.RegisterAssemblyTypes(Assembly.Load("Andy.Mes.Application"))
                .Where(t => t.IsSubclassOf(typeof(ServiceBase)))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(CacheInterceptor));
                //.EnableClassInterceptors();
           

            //serilog
            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("./Logs/logs-.log",rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 1024*10,
                    rollOnFileSizeLimit: true, 
                    shared: true, 
                    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .CreateLogger();
            }).SingleInstance();


            // Typed registration
            builder.Register(c => new CacheInterceptor(c.Resolve<ILogger>()));

            //services auto writed for controller
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t))
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            //automapper
            List<Assembly> ass = new List<Assembly>();
            ass.AddRange(Assembly.Load("Andy.Mes.Web").GetTypes().Where(w=>w.IsAssignableFrom(typeof(ViewModelBase))).Select(x => x.Assembly));
            ass.AddRange(Assembly.Load("Andy.Mes.Entity").GetTypes().Select(x => x.Assembly));
            builder.RegisterModule(new AutoMapperModule(ass));
        }

    }
}
