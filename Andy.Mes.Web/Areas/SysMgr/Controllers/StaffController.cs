using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andy.Mes.Application;
using Andy.Mes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Mes.Web.Areas.SysMgr.Controllers
{
    [Area("SysMgr")]
    public class StaffController : ControllerBase
    {
        public IStaffService StaffService { get; set; }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult List()
        {
            StaffDeviceViewModel search = new StaffDeviceViewModel() { DeviceName = "GPS2" , StaffJob= "CEO"};

            var res = StaffService.List(search);

            return Json(res);
        }

    }
}
