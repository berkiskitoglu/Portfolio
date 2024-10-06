using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Helpers;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult SkillList(int sayfa = 1)
        {
            var values = context.Skill.ToList().ToPagedList(sayfa,5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");

        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Icon = skill.Icon;
            value.Rate = skill.Rate;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult Graphics()
        {
            var grafikCiz = new Chart(width: 600, height: 600);

           
            grafikCiz.AddTitle("Yetenek - Oran")
                     .AddLegend("Oran")
                     .AddSeries(
                        name: "değerler", chartType: "pie",
                        xValue: context.Skill.Where(x => x.Status == true)
                                             .Select(x => x.SkillName) 
                                             .ToList(),
                        yValues: context.Skill.Where(y => y.Status == true)
                                              .Select(z => z.Rate) 
                                              .ToList()
                     ).Write();

            return File(grafikCiz.ToWebImage().GetBytes(), "image/jpg");

        }
    }
}