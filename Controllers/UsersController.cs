using Books.Models;
using Books.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BCrypt.Net;
using Books.Utilities;
using Books.Authorization;
using TLMS.WebApp.Authorization;

namespace Books.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignUp()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ViewBag.ErrorMessage = "Passwords do not match.";
                    return View(model);
                }

                bool existingUser = _context.Users.Any(u => u.UserName == model.UserName);
                if (existingUser)
                {
                    ViewBag.ErrorMessage = "Username is already taken.";
                    return View("Index", model);
                }

                var hashedPassword = Security.Encrypt(model.Password);

                var newUser = new User
                {
                    UserName = model.UserName,
                    Password = hashedPassword
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();
                ViewBag.ErrorMessage = "Done";

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]



        public ActionResult Language(string lang)
        {

            HttpCookie cookie = new HttpCookie("lang", lang);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string deviceId = Request.UserAgent;

                var pass = Security.Encrypt(model.Password);
                var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == pass);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                    return View(model);
                }
                VTSAuth auth = new VTSAuth();

                User loggedUser = new User()
                {
                    UserName = model.UserName,
                    Password = pass,
                   
                };
                //Session session = new Session()
                //{
                //    UserId = user.Id,
                //    DeviceId = deviceId,
                //    ExpirationTime = DateTime.Now.AddHours(3)
                //};
                //_context.Sessions.Add(session);

                auth.SaveToCookies(loggedUser);
                _context.SaveChanges();


                TempData["UserName"] = user.UserName;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            VTSAuth auth = new VTSAuth();

            auth.ClearCookies();

            return RedirectToAction("Login");
        }
    }
}
