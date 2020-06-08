using Andy.Mes.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Persistence
{
    public class DbFactory
    {
        #region 外部接口

        /// <summary>
        /// 根据配置文件获取数据库类型，并返回对应的工厂接口
        /// </summary>
        /// <param name="conString">链接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IRepository GetRepository(string conString, DatabaseType? dbType)
        {
            //conString = conString.IsNullOrEmpty() ? "sql" : conString;
            //conString = DbProviderFactoryHelper.GetConStr(conString);
            dbType = dbType.IsNullOrEmpty() ?  DatabaseType.SqlServer : dbType;

            Type dbRepositoryType = Type.GetType("Andy.Mes.Persistence." + DbProviderFactoryHelper.DbTypeToDbTypeStr(dbType.Value) + "Repository");

            var repository = Activator.CreateInstance(dbRepositoryType, new object[] { conString }) as IRepository;

            //请求结束自动释放
            try
            {
                //AutofacHelper.GetScopeService<IDisposableContainer>().AddDisposableObj(repository);
            }
            catch
            {

            }

            return repository;
        }

        /// <summary>
        /// 获取ShardingRepository
        /// </summary>
        /// <returns></returns>
        //public static IShardingRepository GetShardingRepository()
        //{
        //    return new ShardingRepository(GetRepository());
        //}

        /// <summary>
        /// 根据参数获取数据库的DbContext
        /// </summary>
        /// <param name="conString">初始化参数，可为连接字符串或者DbContext</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IRepositoryDbContext GetDbContext(string conString, DatabaseType dbType)
        {
            IRepositoryDbContext dbContext = new RepositoryDbContext(conString, dbType);
            dbContext.Database.SetCommandTimeout(5 * 60);

            return dbContext;
        }

        #endregion
    }

}
