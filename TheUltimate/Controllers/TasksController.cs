using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;
using TheUltimate.Models;
using TheUltimate.Services.Interfaces;

namespace TheUltimate.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskHandler taskHandler;
        private readonly IInterpreter interpreter;

        public TasksController(ITaskHandler taskHandler, IInterpreter interpreter)
        {
            this.taskHandler = taskHandler;
            this.interpreter = interpreter;
        }

        //
        // GET: /Task/

        public ViewResult Index()
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

        [HttpPost]
        public JsonResult InterpretCommand(CommandViewModel command)
        {
            // TODO: need to add an extra field to contain arbitrary data -> like a task to display to the user!
            Command resultCommand = interpreter.Interpret(command.Line);
            return Json(resultCommand);
        }
    }
}
