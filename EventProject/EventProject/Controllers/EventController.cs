using Microsoft.AspNetCore.Mvc;
using events.Models;
using Microsoft.EntityFrameworkCore;
using events.data;

namespace events.Controllers
{
    public class EventController : Controller

    {
        private readonly WeppAppDbContext wppAppDbContext;

        public EventController( WeppAppDbContext wppAppDbContext)
        {
            this.wppAppDbContext = wppAppDbContext;
        }


        // Display the Add Event form (GET request)
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Handle the form submission (POST request)
        [HttpPost]
        public async Task<IActionResult> Add(Eventtype eventRequest)
        {
            var newEvent = new Eventtype()
            {
                // EventTypeID is auto-generated, so no need to set it here
                EventTypeName = eventRequest.EventTypeName,
                Price = eventRequest.Price,
                Description = eventRequest.Description
            };

            await wppAppDbContext.Event_type.AddAsync(newEvent); // Save the event to the database
            await wppAppDbContext.SaveChangesAsync(); // Commit the changes
            return RedirectToAction("Index"); // Redirect to Index or desired page after adding
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eventtpes = await wppAppDbContext.Event_type.ToListAsync();
            return View(eventtpes);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var stddetails = await wppAppDbContext.Event_type.FirstOrDefaultAsync(x => x.EventTypeID == id);
            if (stddetails != null)
            {
                var fillstudentDetails = new Update()
                {
                    EventTypeID = stddetails.EventTypeID,  // Use the existing ID, not a new one
                    EventTypeName = stddetails.EventTypeName,
                    Price = stddetails.Price,
                    Description = stddetails.Description,
                  
                };
                return View(fillstudentDetails);
            }
            return RedirectToAction("Index"); // Added "return" to ensure all paths return an IActionResult
        }
        [HttpPost]
        public async Task<IActionResult> Update(Update updateStudentRequest)
        {
            var eventinfo = await wppAppDbContext.Event_type.FindAsync(updateStudentRequest.EventTypeID);
            if (eventinfo != null)
            {
                eventinfo.EventTypeName = updateStudentRequest.EventTypeName;
                eventinfo.Price = updateStudentRequest.Price;
                eventinfo.Description = updateStudentRequest.Description;
               

                await wppAppDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = await wppAppDbContext.Event_type.FindAsync(id);
            if (eventToDelete != null)
            {
                wppAppDbContext.Event_type.Remove(eventToDelete);
                await wppAppDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}