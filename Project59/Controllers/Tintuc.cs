using Microsoft.AspNetCore.Mvc;
using Project59.Models;

namespace Project59.Controllers
{
    public class Tintuc : Controller
    {
        Project59Context db = new Project59Context();
        public async Task<IActionResult> Index()

        {
            await Task.WhenAll(tintuc());
            return View();
        }
        public async Task tintuc()
        {
            var tin = db.Tintucs.Where(x=>x.Trangthai==true).ToList();
            ViewBag.Tin  = tin;

        }
    }
}
