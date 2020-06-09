using Andy.Mes.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Application
{
    public interface IUserService
    {
        IEnumerable<SysMgrUser> List();

        SysMgrUser GetById();

        void Update(SysMgrUser entity);

        void Create(SysMgrUser entity);

        void Delete(string guid);

    }
}
