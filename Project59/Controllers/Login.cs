using Microsoft.AspNetCore.Mvc;
using Project59.Models;

namespace Project59.Controllers
{
    public class Login : Controller
    {
        Project59Context db = new Project59Context();
        [HttpGet]
        [Route("dang-nhap.html", Name = "Dangnhap")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("taikhoan")==null)
            {
                return View();
            }
            else
            {
                string role = HttpContext.Session.GetString("taikhoan");
                if (role == "Admin") 
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }
        [HttpPost]
        public IActionResult login(Taikhoan user)
        {
            if (HttpContext.Session.GetString("taikhoan")==null)
            {
                var acc= db.Taikhoans.Where(x=>x.Taikhoan1.Equals(user.Taikhoan1)&&x.Matkhau.Equals(user.Matkhau)).FirstOrDefault();
                if(acc!=null)
                {
                    HttpContext.Session.SetString("taikhoan", acc.Taikhoan1.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại.";
            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("taikhoan");
            return RedirectToAction("Index", "Login");
        }
    }
}
