using AspNetFinalProject.Models;
using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class AcademicBackgroundController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();

        // GET: Admin/AcademicBackground
        public ActionResult Index()
        {
            var Acbg =db.AcademicBackGround.OrderByDescending(a=>a.Id).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_AcademicBgListPartial.cshtml", Acbg);
            }
            return View(Acbg);
        }

        public ActionResult Create()
        {
            var Acbg = db.AcademicBackGround.ToList();

            return View(Acbg);
        }
        [HttpPost]
        public ActionResult Create(AcademicBackground AcBackground)
        {           
            db.AcademicBackGround.Add(AcBackground);
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var AcademicBG = db.AcademicBackGround.Find(id);

            if (AcademicBG == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_AcademicBgPartial.cshtml", AcademicBG);
            }
            return View(AcademicBG);
        }


        [HttpPost]
        public ActionResult Edit(AcademicBackground AcBG)
        {
            AcademicBackground entity = db.AcademicBackGround.Find(AcBG.Id);
            if (entity==null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.BeginDate = AcBG.BeginDate;
                entity.GraduateDate = AcBG.GraduateDate;
                entity.Title = AcBG.Title;
                entity.Content = AcBG.Content;
                entity.Location = AcBG.Location;
                entity.Faculty = AcBG.Faculty;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}