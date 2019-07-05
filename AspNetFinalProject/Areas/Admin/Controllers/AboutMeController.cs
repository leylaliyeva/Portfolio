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
    public class AboutMeController : Controller
    {
        ResumeDbContext db = new ResumeDbContext();

        public ActionResult Edit(AboutMe about)
        {
            about = db.AboutMe.FirstOrDefault();
            return View(about);
        }

        [HttpPost]
        public ActionResult Edit(AboutMe about, HttpPostedFileBase mediaUrl, string fileName)
        {
            AboutMe entity = db.AboutMe.Find(about.Id);
            if (entity == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ModelState.Remove("mediaUrl");

            if (mediaUrl != null)
            {
                bool valid = true;
                if (!mediaUrl.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Photo is not required!");
                    valid = false;
                }

                if (!mediaUrl.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Photo is not required!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = mediaUrl.SaveImage(Server.MapPath("~/Uploads"));
                    if (!string.IsNullOrWhiteSpace(entity.MediaUrl))
                        Server.MoveFile("~/Uploads"
                            , entity.MediaUrl
                            , string.Format("archive/{0}-{1}", entity.Id, entity.MediaUrl));

                    entity.MediaUrl = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(entity.MediaUrl)
                && string.IsNullOrWhiteSpace(fileName))
            {
                entity.MediaUrl = null;
            }


            if (ModelState.IsValid)
            {
                entity.Name = about.Name;
                entity.Location = about.Location;
                entity.Phone = about.Phone;
                entity.Website = about.Website;
                entity.Degree = about.Degree;
                entity.CareerLevel = about.CareerLevel;
                entity.Age = about.Age;
                entity.Email = about.Email;
                entity.Fax = about.Fax;
                entity.Experience = about.Experience;

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }

            return View(about);
        }

    }
}