using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult PartialContactSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactDetail()
        {
            ViewBag.address = context.Profile.Select(x => x.Adress).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            return PartialView();
        }
    }
}