using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project59.Models;
using Project59.Models.authentication;
using System.Drawing.Printing;
using X.PagedList;

namespace Project59.Controllers
{
    public class HomeController : Controller
    {
        Project59Context db = new Project59Context();

        [Authentication]
        public  IActionResult Index( int? page )
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var blog = db.Posts.Where(z => z.Trangthai == true).ToList();

            PagedList<Post> lst = new PagedList<Post>(blog,pageNumber,pageSize);
            return View(lst); 
        }
        [Route("chi-tiet-blog.html", Name = "Chitiet")]
        public IActionResult BlogsDeltail(int id)
        {
            var deltail = db.Posts.FirstOrDefault(p => p.PostId == id);
            var relatedPosts = db.Posts.Where(p => p.Loai == deltail.Loai && p.PostId != id).ToList();
            ViewBag.lienquan = relatedPosts;
            
            return View(deltail);
        }
    }
}
