using Andy.Mes.Core.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Andy.Mes.Application
{
    public class TestBase
    {
        protected AutofacServiceProvider _autofacServiceProvider;

        [SetUp]
        public void Init()
        {
            var serviceCollection = GetService();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddOptions();

            SystemConfig.Config = new SystemConfig()
            {
                DbConfig = new DbConfig()
                {
                    ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mes;Integrated Security=True",
                    Provider = "SqlServer"
                }
            };

            var builder = new ContainerBuilder();
            //regist service
            builder.RegisterAssemblyTypes(Assembly.Load("Andy.Mes.Application"))
                .Where(t => t.IsSubclassOf(typeof(ServiceBase)))
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            _autofacServiceProvider = new AutofacServiceProvider(builder.Build()); 
        }

        /// <summary>
        /// 测试框架默认只注入了缓存Cache，配置Option；
        /// 如果在测试的过程中需要模拟登录用户，cookie等信息，需要重写该方法，可以参考TestFlow的写法
        /// </summary>
        public virtual ServiceCollection GetService()
        {
            return new ServiceCollection();
        }
    }
}
