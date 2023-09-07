using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Project59.Models.authentication
{
    public class Authentication:ActionFilterAttribute
    {
        //Kiểm tra xác thực
        public void Onacti(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("taikhoan")==null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"Controller","Login" },
                        {"Action","login" }
                    }
                    ); 
            }
        }
    }
}
