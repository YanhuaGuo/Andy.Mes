using Andy.Mes.Core;
using Andy.Mes.Core.Configuration;
using Andy.Mes.Entity;
using Andy.Mes.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Andy.Mes.Application
{
    public class AccountService : ServiceBase, IAccountService
    {
        public Result Login(string userName,string pwd)
        {
            //Logger.Debug("user:{0} already login!", input.Username);


            var db = DbFactory.GetRepository(SystemConfig.Config.DbConfig.ConnectionString, DatabaseType.SqlServer);
            Base_UnitTest data = new Base_UnitTest
            {
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                Age = 10,
                UserName = Guid.NewGuid().ToString()
            };
            db.Insert(data);


            return Result.CreateResult(true, "ok");
        }
    }
}
