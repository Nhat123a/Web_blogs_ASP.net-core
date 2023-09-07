using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Project59.Models;
using Project59.Models.authentication;

namespace Project59.Controllers
{
    public class HomeController : Controller
    {
        Project59Context db = new Project59Context();

        [Authentication]
        public  IActionResult Index()
        {

            var blog = db.Posts.Where(z => z.Trangthai == true).ToList();
            ViewBag.Blog = blog;
            
            return View(); 
        }
        public IActionResult BlogsDeltail(int id)
        {
            var deltail = db.Posts.FirstOrDefault(p => p.PostId == id);
            var relatedPosts = db.Posts.Where(p => p.Loai == deltail.Loai && p.PostId != id).ToList();
            ViewBag.lienquan = relatedPosts;
            
            return View(deltail);
        }
        public IActionResult Banner()
        {
            try
            {
                var banner = db.Banners.Where(y => y.Trangthai == true).ToList();
                ViewBag.Banner = banner;
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Có lỗi xảy ra trong quá trình truy vấn cơ sở dữ liệu: " + ex.Message;

            }
            return PartialView("_Header");
        }
    }
}
