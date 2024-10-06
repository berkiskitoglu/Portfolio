using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PortfolioProject.Controllers
{
   
    public class MesajController : Controller
    {
        // GET: Mesaj
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        
        public ActionResult Inbox()
        {
            var value = context.Contact.ToList();   
            return View(value);
        }
     
        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult OpenMesaj(int id)
        {
           
            var value = context.Contact.Where(x => x.ContactId == id).ToList();
            var message = context.Contact.Find(id);
            if(message!=null)
            {
                message.IsRead = true;
                context.SaveChanges();
            }
            return View(value);
        }
        public ActionResult DeleteMesaj(int id)
        {
            var mesaj = context.Contact.Find(id);
            context.Contact.Remove(mesaj);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        
    }
}