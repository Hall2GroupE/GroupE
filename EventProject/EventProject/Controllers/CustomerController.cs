using events.data;
using events.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace events.Controllers
{
    public class CustomerController : Controller

    {
        private readonly WeppAppDbContext weeppAppDbContext;

        public CustomerController(WeppAppDbContext weeppAppDbContext)
        {
            this.weeppAppDbContext = weeppAppDbContext;
        }

       
        [HttpGet]
        public IActionResult Createcustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Createcustomer(Customers CustomertRequest)
        {
            var Customer = new Customers()
            {
                // EventTypeID is auto-generated, so no need to set it here
                FullName = CustomertRequest.FullName,
                Email = CustomertRequest.Email,
                Phone = CustomertRequest.Phone,
                Address = CustomertRequest.Address,
                RegisteredDate = CustomertRequest.RegisteredDate
            };

            await weeppAppDbContext.Customers.AddAsync(Customer); // Save the event to the database
            await weeppAppDbContext.SaveChangesAsync(); // Commit the changes
            return RedirectToAction("Index"); // Redirect to Index or desired page after adding
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eventtpes = await weeppAppDbContext.Customers.ToListAsync();
      ViewData["list"] = eventtpes;
            return View();
        }
    [HttpGet]
    public async Task<IActionResult> UpdateCust(int id)
    {
      var updatecust = await weeppAppDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
      if (updatecust != null)
      {
        var fillstudentDetails = new UpdateCust()
        {
          CustomerID = updatecust.CustomerID,
          FullName = updatecust.FullName,
          Email = updatecust.Email,
          Phone = updatecust.Phone,
          Address = updatecust.Address,
          RegisteredDate = updatecust.RegisteredDate
        };

        ViewData["UpdateCust"] = fillstudentDetails; // Set the data in ViewData if using ViewData in the view
        return View(fillstudentDetails); // Or return View(ViewData["UpdateCust"]);
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
        public async Task<IActionResult> UpdateCust(UpdateCust updateCustomerRequest)
        {
            var customerInfo = await weeppAppDbContext.Customers.FindAsync(updateCustomerRequest.CustomerID);
            if (customerInfo != null)
            {
                customerInfo.FullName = updateCustomerRequest.FullName;
                customerInfo.Email = updateCustomerRequest.Email;
                customerInfo.Phone = updateCustomerRequest.Phone; // Fixed assignment
                customerInfo.Address = updateCustomerRequest.Address;
                customerInfo.RegisteredDate = updateCustomerRequest.RegisteredDate;

                await weeppAppDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = await weeppAppDbContext.Customers.FindAsync(id);
            if (eventToDelete != null)
            {
                weeppAppDbContext.Customers.Remove(eventToDelete);
                await weeppAppDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
