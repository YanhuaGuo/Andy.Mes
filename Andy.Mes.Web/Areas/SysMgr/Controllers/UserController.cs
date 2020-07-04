using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andy.Mes.Application;
using Andy.Mes.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Mes.Web.Areas.SysMgr.Controllers
{
    [Area("SysMgr")]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }

        // GET: UserController
        public ActionResult Index()
        {
            var set = UserService.List();
            var vm = set.Select(x => ObjectMapper.Map<SysMgrUserViewModel>(x));
            return View(vm);
        }

        // GET: UserController/Details/5
        public ActionResult Details(string id)
        {
            var ent = UserService.GetById(id);
            var vm = ObjectMapper.Map<SysMgrUserViewModel>(ent);
            return View(vm);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SysMgrUserViewModel input)
        {
            try
            {
                var ent = ObjectMapper.Map<SysMgrUser>(input);
                UserService.Create(ent);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception es)
            {
                Logger.Error(es,"create fault");
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            var ent = UserService.GetById(id);
            var vm = ObjectMapper.Map<SysMgrUserViewModel>(ent);
            return View(vm);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SysMgrUserViewModel input)
        {
            try
            {
                var ent = ObjectMapper.Map<SysMgrUser>(input);
                UserService.Update(ent);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
        {
            UserService.Delete(id);
            return View();
        }

        // POST: UserController/Delete/5
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
    }
}
