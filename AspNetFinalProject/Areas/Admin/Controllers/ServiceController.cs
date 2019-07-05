using AspNetFinalProject.Models;
using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class ServiceController : Controller
    {
        // GET: Admin/Service

        ResumeDbContext db = new ResumeDbContext();
        [ValidateInput(false)]
        public ActionResult Index()
        {
            var Services = db.Service.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_ServiceListPartial.cshtml", Services);

            }
            return View(Services);
        }


        public ActionResult Create()
        {
            var ser = db.Service.ToList();

            return View(ser);
        }


        [HttpPost]
        public ActionResult Create(Services service)
        {
            db.Service.Add(service);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ser = db.Service.Find(id);

            if (ser == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_ServiceEditPartial.cshtml", ser);
            }
            return View(ser);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Services AcBG)
        {
            Services entity = db.Service.Find(AcBG.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Content = AcBG.Content;
                entity.Title = AcBG.Title;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}