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
        public IActionResult AddTrip()
        {
            TripDetail model = new TripDetail();

            return View(model);
        }
        [HttpPost]
        public IActionResult AddTrip(TripDetail tripDetail)
        {
            if(ModelState.IsValid)
            {
                _TripService.AddTrip(tripDetail);
            }
            TempData["Message"] = "Successfully Created";
            return RedirectToAction("Index");
        }
    }
}
