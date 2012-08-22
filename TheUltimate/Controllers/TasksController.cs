using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUltimate.Models;
using TheUltimate.Services.Interfaces;

namespace TheUltimate.Controllers
{
    public class TasksController : Controller
    {
        private ITaskHandler taskHandler;

        public TasksController(ITaskHandler taskHandler)
        {
            this.taskHandler = taskHandler;
        }

        //
        // GET: /Task/

        public ActionResult Index()
        {
            var userTasks = taskHandler.GetTasks();
            return View(userTasks);
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ParseCommand()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult ParseCommand(IDictionary<string, object> command)
        {
            throw new NotImplementedException();
        }
    }
}
