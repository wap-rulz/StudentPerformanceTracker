using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformanceTracker.Data;

namespace StudentPerformanceTracker.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: AuthenticationController
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewData["HideNavBar"] = true;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(String username, String password)
        {
            var user = InMemoryDatabase.Users.SingleOrDefault();

            if (username == user.Username && password == user.Password)
            {
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "StudySession");
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction(nameof(Login));
        }
    }
}
