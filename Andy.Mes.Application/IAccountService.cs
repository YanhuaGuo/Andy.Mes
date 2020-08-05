using Andy.Mes.Core;

namespace Andy.Mes.Application
{
    public interface IAccountService
    {
        Result Login(string username,string pwd);
    }
}
