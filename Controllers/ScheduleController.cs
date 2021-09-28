using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKVGU.Repositories;
using OKVGU.Services;

namespace OKVGU.Controllers
{
    public class ScheduleController : Controller
    {
        private IScheduleRepository scheduleRepository = new ScheduleRepository();
        private IScheduleService scheduleService;
        // GET: Create
        public ScheduleController()
        {
            scheduleService = new ScheduleService(scheduleRepository);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateSchedule(int? semesterId)
        {
            if (semesterId != null)
            {
                scheduleService.Generate(semesterId.Value);
            }
            return View("Result", scheduleService.GetGroups());
            //return RedirectToAction("Index", "Home");
        }


    }
}