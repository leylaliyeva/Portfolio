using AspNetFinalProject.Models;
using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class ProfessionalExperiencesController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();
        // GET: Admin/ProfessionalExperiences
        public ActionResult Index()
        {
            var prEx = db.ProffesionalExperience.ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_PrExListPartial.cshtml", prEx);
            }
            return View(prEx);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( ProffesionalExperience PE)
        {
            var aa = db.ProffesionalExperience.ToList();

            db.ProffesionalExperience.Add(PE);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            ProffesionalExperience PE = db.ProffesionalExperience.Find(id);
            if (PE == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_PrExEditParttial.cshtml", PE);
            }
            return View(PE);
        }

        [HttpPost]
        public ActionResult Edit(ProffesionalExperience ProExp)
        {
            ProffesionalExperience entity = db.ProffesionalExperience.Find(ProExp.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Title = ProExp.Title;
                entity.Content = ProExp.Content;
                entity.BeginDate = ProExp.BeginDate;
                entity.GraduateDate = ProExp.GraduateDate;
                entity.Job = ProExp.Job;
                entity.Location = ProExp.Location;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
} 