using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLoginApi.Context;
using WebApplicationLoginApi.Models;

namespace WebApplicationLoginApi.Controllers
{
    public class LoginController : Controller
    {
        Model1 db;
        public LoginController()
        {
            db = new Model1();
        }
        // GET: Login
        public ActionResult Index()
        {
            var date = db.Log_Infos.ToList();
            return View(date);
        }

        public ActionResult PatientRegistration()
        {
            return View();
        }
        public ActionResult DoctorRegistration()
        {
            return View();
        }
        public ActionResult AdminRegistration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientRegistration(Log_Info log)
        {
            if (ModelState.IsValid)
            {
                db.Log_Infos.Add(log);
                db.SaveChanges();
                TempData["MsgAdd"] = "Patient information added successfully";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}