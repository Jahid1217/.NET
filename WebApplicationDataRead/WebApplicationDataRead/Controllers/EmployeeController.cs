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
        public ActionResult info(EmployeeTable emp)
        {
            if(emp.Id> 0)
            {
                return View(emp);
            }
            else
            {
                ModelState.Clear();
                
                return View();

            }
            //return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeInfoSend(EmployeeTable emp)
        {
            //data entry in database
            if (ModelState.IsValid)
            {
                //if(emp.Id > 0)
                //{
                //    var empUpdate = _dbContest.EmployeeTables.Where(x => x.Id == emp.Id).FirstOrDefault();
                //    if (empUpdate != null)
                //    {
                //        empUpdate.Name = emp.Name;
                //        empUpdate.JoingDate = emp.JoingDate;
                //        empUpdate.Email = emp.Email;
                //        empUpdate.Call = emp.Call;
                //        empUpdate.Salay = emp.Salay;
                //        empUpdate.designation = emp.designation;
                //    }
                //}
                //else
                //{
                //    //emp.Id = 0;
                //}
                if (emp.Id <= 0)
                {
                    var empUpdate = _dbContest.EmployeeTables.Where(x => x.Id == emp.Id).FirstOrDefault();
                    if (empUpdate != null)
                    {
                        this. _dbContest.EmployeeTables.Add(emp);
                        _dbContest.SaveChanges();
                        TempData["Success"] = "Employee Added Successfully";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    _dbContest.Entry(emp).State = EntityState.Modified;
                    _dbContest.SaveChanges();
                    TempData["Success"] = "Employee Updated Successfully";
                    return RedirectToAction("Index");
                }
                //_dbContest.EmployeeTables.Add(emp);
                //_dbContest.SaveChanges();
                //TempData["Success"] = "Employee Added Successfully";
                //return RedirectToAction("Index"); 
            }

            return View("info");
            //return View("info");
            //return Content("Employee Added Successfully");
        }

        public ActionResult EmployeeDelete(int? id)
        {
            //var emp = _dbContest.EmployeeTables.Find(id);
            var emp = _dbContest.EmployeeTables.Where( x => x.Id == id).First();
            if (emp != null)
            {
                _dbContest.EmployeeTables.Remove(emp);
                _dbContest.SaveChanges();
                TempData["remove"] = "Employee remove Successfully";
            }
            return RedirectToAction("Index");
        }

        //public ActionResult EmployeeEdit(int id)
        //{
        //    var emp = _dbContest.EmployeeTables.Find(id);
        //    if (emp != null)
        //    {
        //        return View(emp);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}