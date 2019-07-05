using AspNetFinalProject.Models;
using AspNetFinalProject.Models.Entity;
using AspNetFinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFinalProject.Controllers
{
    public class HomeController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();

        [ChildActionOnly]
        public ActionResult SideBar()
        {
            AboutMe About = db.AboutMe.FirstOrDefault();
            return View(About);
        }

        public ActionResult AboutMe()
        {
            AboutMeViewModel VM = new AboutMeViewModel
            {
                About = db.AboutMe.FirstOrDefault(),
                Skills = db.Skills.OrderByDescending(a => a.Id).ToList(),
                Bio = db.Bio.FirstOrDefault(),
                Services = db.Service.OrderByDescending(a => a.Id).ToList()

            };
            return View(VM);
        }

        public ActionResult Resume()
        {
            ResumeViewModel VM = new ResumeViewModel
            {
                Bio = db.Bio.FirstOrDefault(),
                Skills = db.Skills.OrderByDescending(a => a.Id).ToList(),
                AcademicBackgrounds = db.AcademicBackGround.OrderByDescending(a=>a.Id).ToList(),
                ProffesionalExperiences = db.ProffesionalExperience.OrderByDescending(a => a.Id).ToList()
            };
            return View(VM);
        }

        public ActionResult PortFolio()
        {
            var portfolio = db.Portfolio.ToList();
            return View(portfolio);
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult ContactMe()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ContactMe(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.IsRead = false;
                db.Contact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("AboutMe", "Home");
            }

            return View(contact);
        }
    }
}