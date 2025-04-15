using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDataRead.Context;

namespace WebApplicationDataRead.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeesEntities _dbContest = new EmployeesEntities();
        // GET: Employee
        public ActionResult Index()
        {
           
            var date = _dbContest.EmployeeTables.ToList();
            return View(date);
        }

        [HttpGet]
        public ActionResult info()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeInfoSend(EmployeeTable emp)
        {
            //data entry in database
            if (ModelState.IsValid)
            {
                _dbContest.EmployeeTables.Add(emp);
                _dbContest.SaveChanges();
                return RedirectToAction("info"); 
            }

            return View("info");
            //return View("info");
            //return Content("Employee Added Successfully");
        }
    }
}