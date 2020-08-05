using Andy.Mes.Core;
using Andy.Mes.Entity;
using System;
using System.Linq;
using System.Reflection;

namespace Andy.Mes.EntityFrameworkCore
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var names = typeof(SysMgrUser).GetProperties().Where(w =>
            {
                if (w.DeclaringType.Equals(typeof(SysMgrUser)) && w.CustomAttributes.Where(a => a.AttributeType.Name.Equals("NotMappedAttribute")).Any() == false)
                {
                    return true;
                }
                return false;
            }).ToArray();

            Console.WriteLine(String.Join(",", names.Select(e => e.Name).ToArray()));

            foreach (var item in names)
            {
                //NotMappedAttribute
                string propName = item.Name;
                var attrNames = (item.CustomAttributes.Select(e => e.AttributeType.Name).ToArray());
                string str = propName + ":" + string.Join(",", attrNames);
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }

    }
}
