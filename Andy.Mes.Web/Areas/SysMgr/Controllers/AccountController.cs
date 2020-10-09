using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andy.Mes.Application;
using Andy.Mes.Core.Configuration;
using Andy.Mes.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Mes.Web.Areas.Areas.Controllers
{
    [Area("SysMgr")]
    public class AccountController : ControllerBase
    {
        public IAccountService AccountService { get; set; }

        //public AccountController(IAccountService ervice)
        //{


        //}

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()

        {
            if (AccountService == null)
            {
                //test code
            }
            ViewData["db"] = SystemConfig.Config.DbConfig.ConnectionString;
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginDto input)
        {
            try
            {
                UserInfo usr = ObjectMapper.Map<UserInfo>(input);


                AccountService.Login(username: "admin", pwd: "admin");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "error!");
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult TestUI()
        {
            return View();
        }
    }
}
