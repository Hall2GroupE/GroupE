using events.data;
using events.Models;
using Microsoft.AspNetCore.Mvc;

namespace events.Controllers
{
    public class HallssController : Controller
    {
        private readonly WeppAppDbContext wppAppDbContext;

        public HallssController(WeppAppDbContext wppAppDbContext)
        {
            this.wppAppDbContext = wppAppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
