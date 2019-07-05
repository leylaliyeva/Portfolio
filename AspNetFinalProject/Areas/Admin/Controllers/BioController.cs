using AspNetFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using AspNetFinalProject.Models.Entity;
using System.Data.Entity;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class BioController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();

        // GET: Admin/Bio
        public ActionResult Index()
        {
            var bio = db.Bio.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_BioTableBodyPartial.cshtml", bio);
            }
            return View(bio);
           
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bio bio = db.Bio.Find(id);
            if (bio==null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_BioListPartial.cshtml", bio);
            }
            return View(bio);
        }

        [HttpPost]
        public ActionResult Edit (Bio bio)
        {
            Bio entity = db.Bio.Find(bio.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Title = bio.Title;
                entity.Content = bio.Content;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}