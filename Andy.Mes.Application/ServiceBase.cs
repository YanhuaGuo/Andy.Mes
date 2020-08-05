using Andy.Mes.Core;
using Andy.Mes.Core.Configuration;
using Andy.Mes.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

namespace Andy.Mes.Application
{
    public class ServiceBase
    {
        public ILogger Logger { get; set; }

        protected IRepository Repository { get; set; }

        public ServiceBase()
        {
            Repository = DbFactory.GetRepository(SystemConfig.Config.DbConfig.ConnectionString, DatabaseType.SqlServer);
            Repository.HandleSqlLog = System.Console.WriteLine;
        }
    }
}
