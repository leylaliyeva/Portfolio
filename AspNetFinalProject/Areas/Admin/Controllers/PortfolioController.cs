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
    public class PortfolioController : Controller
    {

        ResumeDbContext db = new ResumeDbContext();
        // GET: Admin/Portfolio
        public ActionResult Index()
        {
            var portfolio = db.Portfolio.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_PortfolioListPartial.cshtml", portfolio);
            }
            return View(portfolio);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Portfolio portfolio,HttpPostedFileBase mediaUrl)
        {
            if (mediaUrl == null)
                ModelState.AddModelError("mediaUrl", "Photo doesn't selected!");
            else
            {
                if (!mediaUrl.CheckImageType())
                    ModelState.AddModelError("mediaUrl", "Photo is not required!");
                if (!mediaUrl.CheckImageSize(5))
                    ModelState.AddModelError("mediaUrl", "Photo size is not required!");
            }
            if (!ModelState.IsValid)
            {
                throw new NullReferenceException();
            }
            string newPath = mediaUrl.SaveImage(Server.MapPath("~/Uploads"));

            portfolio.MediaUrl = newPath;
            db.Portfolio.Add(portfolio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Portfolio portfolio = db.Portfolio.Find(id);
            return View(portfolio);
        }


        [HttpPost]
        public ActionResult Edit(Portfolio portfolio, HttpPostedFileBase mediaUrl, string fileName)
        {
            Portfolio entity = db.Portfolio.Find(portfolio.Id);
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
                entity.Name = portfolio.Name;
                entity.Category = portfolio.Category;
                entity.Link = portfolio.Link;
             

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }
    }
}