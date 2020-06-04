using Andy.Mes.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Andy.Mes.Application
{
    public class AccountService : ServiceBase, IAccountService
    {
        public Result Login(LoginDto input)
        {
            Logger.Debug("user:{0} already login!", input.Username);
            return Result.CreateResult(true, "ok");
        }
    }
}
