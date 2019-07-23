using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.CycleModels;
using Tracker.Services;

namespace Tracker.WebMVC.Controllers
{
    [Authorize]
    public class CycleController : Controller
    {
        // GET: Cycle
        public ActionResult Index()
        {
            var service = CreateTrackerService();
            var model = service.ViewAllCycles();
            return View(model);
        }
        public ActionResult CycleCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CycleCreate(CycleCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTrackerService();
            if (service.CreateCycle(model))
            {
                TempData["SaveResult"] = "Your cycle has been entered.";
                return RedirectToAction("Index", "Log");
            }
            ModelState.AddModelError("", "Cycle could not be logged.");
            return View(model);
        }
        public ActionResult CycleDetails (int id)
        {
            var svc = CreateTrackerService();
            var model = svc.GetCycleByID(id);
            return View(model);
        }
        public ActionResult CycleEdit(int id)
        {
            var service = CreateTrackerService();
            var detail = service.GetCycleByID(id);
            var model =
                new CycleUpdate
                {
                    CycleID=detail.CycleID,
                    DateStarted = detail.DateStarted,
                    DateEnded = detail.DateEnded,
                    Comments = detail.Comments
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CycleEdit(int id, CycleUpdate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CycleID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return RedirectToAction("Index", "Log");
            }
            var service = CreateTrackerService();
            if (service.UpdateCycle(model))
            {
                TempData["SaveResult"] = "Your cycle log has been updated.";
                return RedirectToAction("Index", "Log");
            }
            ModelState.AddModelError("", "Your cycle log could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrackerService();
            var model = svc.GetCycleByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCycle(int id)
        {
            var service = CreateTrackerService();
            service.DeleteCycle(id);
            TempData["SaveResult"] = "Your cycle log entry was deleted";
            return RedirectToAction("Index", "Log");
        }

        private CycleService CreateTrackerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CycleService(userID);
            return service;
        }
    }
}