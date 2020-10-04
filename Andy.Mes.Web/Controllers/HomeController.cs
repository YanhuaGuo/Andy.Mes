using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Andy.Mes.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Andy.Mes.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private IMemoryCache _objCache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IMemoryCache objCache)
        {
            _logger = logger;
            _objCache = objCache;
            _logger.LogInformation("homeController has started!");

            string cacheTemp = objCache.GetOrCreate("key", (a) => {
                return "gyh";
            }) ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public string GetToken()
        {
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["Token"];
            return cookie == null ? String.Empty : cookie;
        }


        
        [HttpGet]
        public string Get(string key)
        {
            return _objCache.Get<string>(key);
        }

    }
}
