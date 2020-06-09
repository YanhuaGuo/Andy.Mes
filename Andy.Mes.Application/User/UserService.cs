using Andy.Mes.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andy.Mes.Application
{
    public class UserService : ServiceBase, IUserService
    {
        public void Create(SysMgrUser entity)
        {
            Repository.Insert(entity);
        }

        public void Delete(string guid)
        {
            Repository.Delete<SysMgrUser>(guid);
        }

        public SysMgrUser GetById(string guid)
        {
            return Repository.GetEntity<SysMgrUser>(guid);
        }

        public IEnumerable<SysMgrUser> List()
        {
            return Repository.GetIQueryable<SysMgrUser>().ToList();
        }

        public void Update(SysMgrUser entity)
        {
            Repository.Update(entity);
        }
    }
}
