using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project59.Models;

namespace Project59.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        Project59Context db = new Project59Context();

        public IActionResult Index()
        {
           
                var count = db.Taikhoans.Count();
                
            
            return View(count);
        }

    }
}
