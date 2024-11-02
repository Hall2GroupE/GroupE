using Microsoft.AspNetCore.Mvc;
using System.Linq;
using events.Models;
using events.data;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Controllers
{
  public class EventsController : Controller
  {
    private readonly WeppAppDbContext weeppAppDbContext;

    public EventsController(WeppAppDbContext weeppAppDbContext)
    {
      this.weeppAppDbContext = weeppAppDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var eventlist = await weeppAppDbContext.TblEvents.ToListAsync();
      //var customerslist = await weeppAppDbContext.Customers.ToListAsync();
      //var eventtype = await weeppAppDbContext.Event_type.ToListAsync();
      //var eventtpes = await weeppAppDbContext.Halls.ToListAsync();

      ViewData["list"] = eventlist;
      return View();
    }


    [HttpGet]
    public IActionResult Add()
    {
      // Load data for dropdowns
      var customers = weeppAppDbContext.Customers.ToList();
      var halls = weeppAppDbContext.Halls.ToList();
      var eventTypes = weeppAppDbContext.Event_type.ToList();

      // Pass data to the view using ViewBag
      ViewBag.Customers = customers;
      ViewBag.Halls = halls;
      ViewBag.EventTypes = eventTypes;

      return View();
    }

    [HttpPost]
    public IActionResult Add(Events eventModel)
    {
      if (ModelState.IsValid)
      {
        weeppAppDbContext.TblEvents.Add(eventModel);
        weeppAppDbContext.SaveChanges();
        return RedirectToAction("Index"); // Redirect to the event list or another appropriate page
      }

      // Reload data in case of error and re-render view
      ViewBag.Customers = weeppAppDbContext.Customers.ToList();
      ViewBag.Halls = weeppAppDbContext.Halls.ToList();
      ViewBag.EventTypes = weeppAppDbContext.Event_type.ToList();

      return View(eventModel);
    }

        public async Task<IActionResult> AddEvent(Events eventRequest)
    {
      var newEvent = new Events()
      {
        // EventTypeID is auto-generated, so no need to set it here
        CustomerID = eventRequest.CustomerID,
        NumberOfPeople = eventRequest.NumberOfPeople,
        HallID = eventRequest.HallID,
        EventTypeID = eventRequest.EventTypeID,
        EventName = eventRequest.EventName,
        Hours = eventRequest.Hours,
        EventDate = eventRequest.EventDate,
        Status = eventRequest.Status
      };

      await weeppAppDbContext.TblEvents.AddAsync(newEvent); // Save the event to the database
      await weeppAppDbContext.SaveChangesAsync(); // Commit the changes
      return RedirectToAction("Index"); // Redirect to Index or desired page after adding
    }
  }
}
