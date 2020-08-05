using Andy.Mes.Dto;
using System.Collections;
using System.Collections.Generic;

namespace Andy.Mes.Application
{
    public interface IStaffService
    {
        IEnumerable<StaffDeviceViewModel> List(StaffDeviceViewModel search);
    }
}