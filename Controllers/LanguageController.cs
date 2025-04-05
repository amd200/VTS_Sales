using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult ChangeLanguage(string lang)
        {
            HttpCookie cookie = new HttpCookie("language", lang);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}