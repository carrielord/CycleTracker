using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.BBTModels;
using Tracker.Services;

namespace Tracker.WebMVC.Controllers
{
    public class BasalBodyTempController : Controller
    {
        // GET: BasalBodyTemp
        public ActionResult Index()
        {
            var service = CreateTrackerService();
            var model = service.ViewAllBBTs();
            return View(model);
        }
        public ActionResult BBTCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BBTCreate(BBTCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTrackerService();
            if (service.CreateBBT(model))
            {
                TempData["SaveResult"] = "Your temperature has been entered.";
                return RedirectToAction("Index", "Log");
            }
            ModelState.AddModelError("", "Temperature could not be logged.");
            return View(model);
        }
        public ActionResult BBTDetails(int id)
        {
            var svc = CreateTrackerService();
            var model = svc.GetBBTByID(id);
            return View(model);
        }
        public ActionResult BBTEdit(int id)
        {
            var service = CreateTrackerService();
            var detail = service.GetBBTByID(id);
            var model =
                new BBTUpdate
                {
                    BBTID = detail.BBTID,
                    Temperature = detail.Temperature,
                    DateOfTemp = detail.DateOfTemp,
                    Comments = detail.Comments
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BBTEdit(int id, BBTUpdate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.BBTID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return RedirectToAction("Index", "Log");
            }
            var service = CreateTrackerService();
            if (service.UpdateBBT(model))
            {
                TempData["SaveResult"] = "Your temperature log has been updated.";
                return RedirectToAction("Index", "Log");
            }
            ModelState.AddModelError("", "Your temperature log could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrackerService();
            var model = svc.GetBBTByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBBT(int id)
        {
            var service = CreateTrackerService();
            service.DeleteBBT(id);
            TempData["SaveResult"] = "Your temperature log entry was deleted";
            return RedirectToAction("Index", "Log");
        }


        private BBTService CreateTrackerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BBTService(userID);
            return service;
        }

    }
}