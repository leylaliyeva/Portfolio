using AspNetFinalProject.Models;
using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();

        // GET: Admin/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            if (username == null)
            {
                ViewBag.LoginError = "Please fill a username";
                return View();
            }
            if (password == null)
            {
                ViewBag.LoginError = "Please fill a password";
                return View();
            }
            Login LoggedAdmin = db.Login.Where(a => a.UserName == username).FirstOrDefault();
            if (LoggedAdmin != null && Crypto.VerifyHashedPassword(LoggedAdmin.Password, password))
            {
                Session[SessionKey.AdminSession] = LoggedAdmin;
                return RedirectToAction("Edit", "AboutMe");
            }
            ViewBag.LoginError = "Username or password is wrong!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        // GET: Admin/Admin

    }
}