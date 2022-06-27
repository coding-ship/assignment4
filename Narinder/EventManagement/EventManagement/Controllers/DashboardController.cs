using EventManagement.Models;
using EventManagement.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class DashboardController : Controller
    {
        private EventDbContext db = new EventDbContext();
        public IRepository service;
        public DashboardController(IRepository ser)
        {
            service = ser;
        }
        // GET: DashboardController
        public ActionResult Index()
        {
            return View(db.Venue.ToList());
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(string id)
        {
            VenueDetails venue = service.Details(id); 
            return View(venue);
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueAllDetails venueAllDetails)
        {
            try
            {
                Venue venue = new Venue();
                venue.Event_Place = venueAllDetails.Event_Place;
                venue.Event_Type = venueAllDetails.Event_Type;
                venue.Guest_Capability = venueAllDetails.Guest_Capability;
                venue.Per_Guest_Cost = venueAllDetails.Per_Guest_Cost;
                VenueDetails venueDetails = new VenueDetails();
                venueDetails.Event_Place = venueAllDetails.Event_Place;
                venueDetails.DJ_Cost = venueAllDetails.DJ_Cost;
                venueDetails.Mike_Speaker_Cost = venueAllDetails.Mike_Speaker_Cost;
                venueDetails.Stage_Cost = venueAllDetails.Stage_Cost;
                    
                db.Venue.Add(venue);
                db.VenueDetail.Add(venueDetails);
                db.SaveChanges();
                ViewBag.Message = "New Venue Added Successfully!";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit
        public ActionResult Edit(string id)
        {
            Venue venue = db.Venue.ToList().FirstOrDefault(x => x.Event_Place == id); ;
            return View(venue);
        }

        // POST: DashboardController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,Venue venue)
        {
            Venue data = db.Venue.ToList().FirstOrDefault(x => x.Event_Place == id); 
                data.Event_Type = venue.Event_Type;
                data.Guest_Capability = venue.Guest_Capability;
                data.Per_Guest_Cost = venue.Per_Guest_Cost;
            db.SaveChanges();
            ViewBag.Message = "Record Updated Successfully!";
            return View();
            
        }

        public ActionResult EditDetails(string id)
        {
            VenueDetails venue = db.VenueDetail.ToList().FirstOrDefault(x => x.Event_Place == id); ;
            return View(venue);
        }

        // POST: DashboardController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(string id, VenueDetails venue)
        {
            VenueDetails data = db.VenueDetail.ToList().FirstOrDefault(x => x.Event_Place == id);
            data.DJ_Cost = venue.DJ_Cost;
            data.Stage_Cost = venue.Stage_Cost;
            data.Mike_Speaker_Cost = venue.Mike_Speaker_Cost;
            db.SaveChanges();
            ViewBag.Message = "Record Updated Successfully!";
            return View();

        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(string id)
        {
            Venue data = db.Venue.ToList().FirstOrDefault(x => x.Event_Place == id);

            return View(data);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id,Venue venue)
        {
            try
            {
                Venue data = db.Venue.ToList().FirstOrDefault(x => x.Event_Place == id);
                VenueDetails venueDetails = db.VenueDetail.ToList().FirstOrDefault(x => x.Event_Place == id);
                db.VenueDetail.Remove(venueDetails);
                db.Venue.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Search()
        {
            return View();
        }

        // POST: DashboardController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(VenueAllDetails venue)
        {  
            return RedirectToAction("ShowSearchedVenue", new { id = venue.Event_Place });
        }

        public ActionResult ShowSearchedVenue(string id)
        {
            Venue Venue = db.Venue.FirstOrDefault(x => x.Event_Place == id);
            if (Venue == null)
            {
                ViewBag.Error = "Venue does not exists in record!";
                return View();
            }
            else
            {
                VenueDetails VenueDetails = db.VenueDetail.FirstOrDefault(x => x.Event_Place == id);
                VenueAllDetails venueAllDetails = new VenueAllDetails();
                venueAllDetails.Event_Place = Venue.Event_Place;
                venueAllDetails.Event_Type = Venue.Event_Type;
                venueAllDetails.Guest_Capability = Venue.Guest_Capability;
                venueAllDetails.Per_Guest_Cost = Venue.Per_Guest_Cost;
                venueAllDetails.DJ_Cost = VenueDetails.DJ_Cost;
                venueAllDetails.Mike_Speaker_Cost = VenueDetails.Mike_Speaker_Cost;
                venueAllDetails.Stage_Cost = VenueDetails.Stage_Cost;
                return View(venueAllDetails);
            }
        }
    }
}
