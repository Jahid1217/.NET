using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLoginReg.Context;

namespace WebApplicationLoginReg.Controllers
{
    public class RegistrationController : Controller
    {
        User _dbContest = new User();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        // POST: Registration

        public ActionResult RegistrationAdd(User user) 
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationSave(User user)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, return the view with the current user data and validation messages
                return View("RegistrationAdd", user);
            }

            try
            {
                this._dbContest.UserId = user.UserId;
                _dbContest.SaveChanges();
                TempData["Success"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown here)
                TempData["Error"] = "An error occurred while saving the user. Please try again.";
                return View("RegistrationAdd", user);
            }
        }
    }
}