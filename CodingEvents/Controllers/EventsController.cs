using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {


        // GET: /<controller>/
        //[HttpGet]
        public IActionResult Index()
        {

            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
                   
        return Redirect("/Events");
        }
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //controller code here
            Event EditEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.title = $"Edit Event {EditEvent.Name} (Id = {EditEvent.Id})";
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            //    //controller code here
            Event EditEvent = EventData.GetById(eventId);
            EditEvent.Name = name;
            EditEvent.Description = description;
            return Redirect("/Events");
        }
    }
}
