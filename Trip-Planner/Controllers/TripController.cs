using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Model_Classes.Model;

namespace Trip_Planner.Controllers
{
    public class TripController : Controller
    {
        private ITripService _TripService;

        public TripController(ITripService TripService)
        {
            _TripService = TripService;
        }
        public IActionResult Index()
        {
            var model = _TripService.GetTripDetails();
            if(TempData["Message"] !=null)
            {
                ViewBag.Msg = TempData["Message"];
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddEditTrip(int Id = 0)
        {
            TripDetail model = _TripService.GetTrip(Id);
            //TripDetail model = new TripDetail();

            return View(model);
        }
        [HttpPost]
        public IActionResult AddEditTrip(TripDetail tripDetail)
        {
            if(ModelState.IsValid)
            {
                int TripId = _TripService.AddOrEditTrip(tripDetail);
            }
            TempData["Message"] = "Successfully Created";
            return RedirectToAction("Index");
        }
    }
}
