using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAccounrt.ConText;

namespace WebApplicationAccounrt.Controllers
{
    public class CreateAccountController : Controller
    {
        // GET: CreateAccount
        AccountDBEntities _ConTextDB = new AccountDBEntities();
        public ActionResult Index()
        {
            var date = _ConTextDB.Accounts.ToList();
            return View(date);
        }
        public ActionResult AccountInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountInfoSave(Account acc)
        {
            if (ModelState.IsValid)
            {
                _ConTextDB.Accounts.Add(acc);
                _ConTextDB.SaveChanges();
                TempData["Success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View("AccountInfo", acc);
        }

       
        public ActionResult AccountInfoDelete(int? Id)
        {
            var acc = _ConTextDB.Accounts.Where(x => x.Id == Id).First();
            if (acc != null)
            {
                _ConTextDB.Accounts.Remove(acc);
                _ConTextDB.SaveChanges();

            }
            return RedirectToAction("Index");
        } 
        }
}