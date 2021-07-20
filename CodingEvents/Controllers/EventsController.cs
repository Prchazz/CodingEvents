using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private List<string> Events = new List<string>();
        // GET: /<controller>/
        //[HttpGet]
        public IActionResult Index()
        {
            
            //Events.Add("Strange Loop");
            //Events.Add("Grace hopper");
            //Events.Add("Code with Pride");
            ViewBag.events = Events;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("/Events/Add")]
        public IActionResult NewEvent(string name)
        {
            Events.Add(name);
            return Redirect("/Events");
        }
    }
}
