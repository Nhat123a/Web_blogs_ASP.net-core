using Microsoft.AspNetCore.Mvc;

namespace Project59.Controllers
{
    public class Lienhe : Controller
    {
        [Route("lien-he.html", Name = "Lienhe")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
