using Andy.Mes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Application
{
    public interface IAccountService
    {
        Result Login(string username,string pwd);
    }
}
