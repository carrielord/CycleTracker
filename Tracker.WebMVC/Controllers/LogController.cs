using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Services;

namespace Tracker.WebMVC.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            dynamic logView = new ExpandoObject();
            var serviceCycle = CreateTrackerServiceCycle();
            var serviceBBT = CreateTrackerServiceBBT();
            logView.Cycle = serviceCycle.ViewAllCycles();
            logView.BBT = serviceBBT.ViewAllBBTs();
            return View(logView);
        }
        public ActionResult GoToViews()
        {
            return View();
        }
        private CycleService CreateTrackerServiceCycle()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CycleService(userID);
            return service;
        }
        private BBTService CreateTrackerServiceBBT()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BBTService(userID);
            return service;
        }

    }
}