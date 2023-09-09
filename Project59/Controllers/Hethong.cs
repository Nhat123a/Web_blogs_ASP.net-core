using Microsoft.AspNetCore.Mvc;

namespace Project59.Controllers
{
    public class Hethong : Controller
    {
        [Route("404-notfound.html", Name = "Hethong")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
