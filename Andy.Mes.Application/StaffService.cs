using Andy.Mes.Core;
using Andy.Mes.Dto;
using Andy.Mes.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Andy.Mes.Application
{
    public class StaffService : ServiceBase, IStaffService
    {
        public IEnumerable<StaffDeviceViewModel> List(StaffDeviceViewModel search)
        {
            var staff = Repository.GetIQueryable<Staff>().Select(s => s);
            var device = Repository.GetIQueryable<Device>().Select(t => t);
            var staffDevice = Repository.GetIQueryable<StaffDevice>().Select(s => s);


            var where1 = LinqHelper.True<StaffDeviceViewModel>();
            if (search.DeviceName.IsNullOrEmpty() == false)
            {
                where1 = where1.And(x => x.DeviceName == search.DeviceName);
            }
            if(search.StaffJob.IsNullOrEmpty() == false)
            {
                where1 = where1.And(s=>s.StaffJob == search.StaffJob);
            }
            try
            {
                var q = from s in staff
                        from d in device
                        from sd in staffDevice
                        where (s.Guid == sd.StaffGuid && d.Guid == sd.DeviceGuid)
                        select new StaffDeviceViewModel
                        {
                            StaffName = s.Name,
                            StaffJob = s.JobName,
                            DeviceName = d.Name
                        };
                ;
                return q.Where(where1).ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
