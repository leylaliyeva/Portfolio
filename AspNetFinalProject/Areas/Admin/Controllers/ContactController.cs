using AspNetFinalProject.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetFinalProject.Areas.Admin.Controllers
{
    [AuthorizeAdminFilter]
    public class ContactController : Controller
    {
        Models.ResumeDbContext db = new Models.ResumeDbContext();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            var contact = db.Contact.OrderByDescending(c => c.Id).ToList();
            return View(contact);
        }

        public ActionResult Read(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Readed = db.Contact.Find(id);
            Readed.IsRead = true;
            db.SaveChanges();
            if (Readed == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_ReadPartial.cshtml", Readed);
            }
            return View(Readed);
        }


        public ActionResult AnswerTo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AnswerTo(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                throw new NullReferenceException();
            }

            Extension.SendMail(answer.ToMail, answer.Subject, answer.Message);
            return RedirectToAction("Index");
        }
    }
}