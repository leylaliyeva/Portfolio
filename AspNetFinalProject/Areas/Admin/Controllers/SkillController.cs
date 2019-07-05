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
    public class SkillController : Controller
    {
        Models.ResumeDbContext db = new Models.ResumeDbContext();
        // GET: Admin/Skill
        public ActionResult Index()
        {
            var skill = db.Skills.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_SkillListPartial.cshtml", skill);
            }
            return View(skill);
        }



        public ActionResult Create()
        {
            Skills skill = new Skills();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_SkillCreatePartial.cshtml",skill);
            }

            return View(skill);
        }
        [HttpPost]
        public ActionResult Create(Skills skill)
        {
            db.Skills.Add(skill);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var skill = db.Skills.Find(id);

            if (skill == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Partials/_SkillEditPartial.cshtml", skill);
            }
            return View(skill);
        }


        [HttpPost]
        public ActionResult Edit(Skills skill)
        {
            Skills entity = db.Skills.Find(skill.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Description = skill.Description;
                entity.Name = skill.Name;
                entity.Percent = skill.Percent;
                entity.SkillType = skill.SkillType;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}