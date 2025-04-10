using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDataRead.Context;

namespace WebApplicationDataRead.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeesEntities _dbContest = new EmployeesEntities();
            var date = _dbContest.EmployeeTables.ToList();
            return View(date);
        }
    }
}