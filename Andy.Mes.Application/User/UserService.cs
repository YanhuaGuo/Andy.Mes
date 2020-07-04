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
            var properties = typeof(SysMgrUser).GetProperties().Where(w =>
            {
                if (w.DeclaringType.Equals(typeof(SysMgrUser)) 
                && w.CustomAttributes.Where(a => a.AttributeType.Name.Equals("NotMappedAttribute")).Any() == false)
                    return true;
                return false;
            }).Select(e=>e.Name).ToList();

            //Console.WriteLine(string.Join(",", properties.Select(e => e.Name).ToArray()));

            //Repository.Update(entity);

            Repository.UpdateAny(entity,properties);
        }
    }
}
