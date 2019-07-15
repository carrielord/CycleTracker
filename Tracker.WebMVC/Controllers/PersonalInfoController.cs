using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.PersonalInfoModels;
using Tracker.Services;

namespace Tracker.WebMVC.Controllers
{
    [Authorize]
    public class PersonalInfoController : Controller
    {
        // GET: PersonalInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PersonalInfoCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoCreate(PersonalInfoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrackerService();
            var userID = User.Identity.GetUserId();

            if (service.CreatePersonalInfo(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("PersonalInfoDetails", "PersonalInfo", new { id = userID });
            }
            ModelState.AddModelError("", "Personal Information could not be added.");
            return View(model);

        }
        public ActionResult PersonalInfoDetails()
        {
            var svc = CreateTrackerService();

            var model = svc.GetPersonalInfoByID(Guid.Parse(User.Identity.GetUserId()));
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("PersonalInfoCreate", "PersonalInfo");
            }
        }

        public ActionResult PersonalInfoEdit(Guid id)
        {
            var service = CreateTrackerService();
            var detail = service.GetPersonalInfoByID(id);
            var model = new PersonalInfoUpdate
            {
                UserId = id,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Age = detail.Age,
                PreviousPregnancies = detail.PreviousPregnancies,
                ViablePreg = detail.ViablePreg,
                FailedPreg = detail.FailedPreg,
                TerminatedPreg = detail.TerminatedPreg,
                WhyUsing = detail.WhyUsing,
                MedicalHistory = detail.MedicalHistory,
                ModifiedTime = DateTimeOffset.Now
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoEdit(Guid id, PersonalInfoUpdate model)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid) return View(model);
            if (model.UserId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateTrackerService();
            if (service.UpdatePersonalInfo(model))
            {
                TempData["SaveResult"] = "Your personal information has been updated.";
                return RedirectToAction("PersonalInfoDetails", "PersonalInfo", new { id = id });
            }
            ModelState.AddModelError("", "Your personal information could not be updated.");
            return View(model);
        }
        public ActionResult Delete(Guid id)
        {
            var svc = CreateTrackerService();
            var model = svc.GetPersonalInfoByID(id);
            return View(model);
            //return RedirectToAction("PersonalInfoDelete", "PersonalInfo", new { id = id });
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoDelete(Guid id)
        {
            var service = CreateTrackerService();
            service.DeletePersonalInfo(id);
            TempData["SaveResult"] = "Your personal information was deleted.";
            return RedirectToAction("PersonalInfoCreate", "PersonalInfo");
        }

        private PersonalInfoService CreateTrackerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonalInfoService(userId);
            return service;
        }
    }
}