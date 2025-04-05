using Books.Authorization;
using Books.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace TLMS.WebApp.Authorization
{
    public class Authorized : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            VTSAuth auth = new VTSAuth() { CookieValues = new User() };

            if (auth.LoadDataFromCookies())
            {
                filterContext.Controller.TempData["UserInfo"] = auth.CookieValues;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Users", action = "Login" }));
            }
        }
    }

    public class Anonymous : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            VTSAuth auth = new VTSAuth() { CookieValues = new User() };

            if (auth.LoadDataFromCookies())
            {
                filterContext.Controller.TempData["UserInfo"] = auth.CookieValues;
            }
            else
            {
                filterContext.Controller.TempData["UserInfo"] = null;
                filterContext.Controller.TempData["UserId"] = null;
                filterContext.Controller.TempData["PersonId"] = null;
            }
        }
    }
}