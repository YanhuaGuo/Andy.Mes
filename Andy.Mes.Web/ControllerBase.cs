using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andy.Mes.Web
{
    public abstract class ControllerBase : Controller
    {
        public ILogger Logger { get; set; }
    }
}
