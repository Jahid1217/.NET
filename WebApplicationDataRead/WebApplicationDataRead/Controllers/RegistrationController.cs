using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDataRead.Context;

namespace WebApplicationDataRead.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public EmployeesEntities1 _dbContesReg = new EmployeesEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(RegistrationUser model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _dbContesReg.RegistrationUsers.FirstOrDefault(u => u.User_Id == model.User_Id);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View("Index");
                }

                var user = new RegistrationUser
                {
                    Full_name = model.Full_name,
                    Email = model.Email,
                    Password = model.Password,
                    User_Id = model.User_Id,
                    Role = model.Role
                };

                _dbContesReg.RegistrationUsers.Add(user);
                _dbContesReg.SaveChanges();

                TempData["Success"] = "Registration successful!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(RegistrationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContesReg.RegistrationUsers.FirstOrDefault(u => u.User_Id == model.User_Id && u.Password == model.Password);
                if (user != null)
                {
                    TempData["Success"] = "Login successful!";
                    return RedirectToAction("info", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View("Login");
        }
    }
}