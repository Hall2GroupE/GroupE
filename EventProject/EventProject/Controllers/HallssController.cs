using AspnetCoreMvcFull.Models;
using events.data;
using events.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace events.Controllers
{
    public class HallssController : Controller
    {
        private readonly WeppAppDbContext wppAppDbContext;

        public HallssController(WeppAppDbContext wppAppDbContext)
        {
            this.wppAppDbContext = wppAppDbContext;
        }
    public async Task<IActionResult> Index()
    {
      var halls = await wppAppDbContext.Halls.ToListAsync();

      return View(halls);
    }
    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Hall hallRequest)
    {
      var hall = new Hall()
      {
        HallName = hallRequest.HallName,
        Capacity = hallRequest.Capacity,
        RentalCost = hallRequest.RentalCost,
        Location = hallRequest.Location
      };

      await wppAppDbContext.Halls.AddAsync(hall);
      await wppAppDbContext.SaveChangesAsync();
      return RedirectToAction("Index");
    }
    // GET: Fetch details of the hall by ID for editing
    [HttpGet]
    public async Task<IActionResult> UpdateHall(int id)
    {
      var hall = await wppAppDbContext.Halls.FirstOrDefaultAsync(x => x.HallID == id);
      if (hall != null)
      {
        var hallDetails = new Hall
        {
          HallID = hall.HallID,
          HallName = hall.HallName,
          Capacity = hall.Capacity,
          RentalCost = hall.RentalCost,
          Location = hall.Location
        };

        ViewData["UpdateHall"] = hallDetails; // Set data in ViewData if needed
        return View(hallDetails);
      }
      return RedirectToAction("Index");
    }

    // POST: Update hall details in the database
    [HttpPost]
    public async Task<IActionResult> UpdateHall(Hall updateHallRequest)
    {
      var hallInfo = await wppAppDbContext.Halls.FindAsync(updateHallRequest.HallID);
      if (hallInfo != null)
      {
        hallInfo.HallName = updateHallRequest.HallName;
        hallInfo.Capacity = updateHallRequest.Capacity;
        hallInfo.RentalCost = updateHallRequest.RentalCost;
        hallInfo.Location = updateHallRequest.Location;

        await wppAppDbContext.SaveChangesAsync();
        return RedirectToAction("Index");

      }
      return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
      var hallToDelete = await wppAppDbContext.Halls.FindAsync(id);
      if (hallToDelete != null)
      {
        wppAppDbContext.Halls.Remove(hallToDelete);
        await wppAppDbContext.SaveChangesAsync();
      }
      return RedirectToAction("Index");
    }

  }
}
