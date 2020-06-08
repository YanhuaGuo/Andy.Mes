
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using Andy.Mes.Core;
using System.Collections.Generic;
using System.Reflection;
using Andy.Mes.Core.Configuration;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andy.Mes.Persistence
{
    public class DbContextBase : DbContext
    {
        private DatabaseType _dbType { get; }
        private DbConnection _dbConnection { get; }
        private IModel _model { get; }

        public DbContextBase(string dbconfig)
        {

        }

        public DbContextBase(DatabaseType dbType, DbConnection existingConnection, IModel model)
        {
            _dbType = dbType;
            _dbConnection = existingConnection;
            _model = model;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (_nameOrConStr.IsNullOrEmpty())
            //    _nameOrConStr = GlobalSwitch.DefaultDbConName;

            string conStr = _dbConnection.ConnectionString;
            int _dbtype = 1;
            switch (_dbtype)
            {
                case 1:
                    optionsBuilder.UseSqlServer(conStr, x => x.UseRowNumberForPaging()).EnableSensitiveDataLogging(); 
                    break;
                case 2:
                    optionsBuilder.UseOracle(conStr);
                    break;
                default: throw new Exception("暂不支持该数据库！");
            }

            //optionsBuilder.UseLoggerFactory(_loger);
        }

        /// <summary>
        /// 初始化DbContext
        /// </summary>
        /// <param name="modelBuilder">模型建造者</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TheEntity>();
            //以下代码最终目的就是将所有需要的实体类调用上面的方法加入到DbContext中，成为其中的一部分
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
            List<Type> types = Assembly.Load($"{SystemConfig.ProjectNamePre}.Entity").GetTypes()
                .Where(x => x.GetCustomAttribute(typeof(TableAttribute), false) != null )
                .ToList();

            foreach (var type in types)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, null);
            }
        }
    }
}
