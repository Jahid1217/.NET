﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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

            if (ModelState.IsValid)
            {
                if (emp.Id <= 0)
                {
                    this._dbContest.EmployeeTables.Add(emp);
                    _dbContest.SaveChanges();
                    TempData["MsgAdd"] = "Employee information added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    _dbContest.Entry(emp).State = EntityState.Modified;
                    _dbContest.SaveChanges();
                    TempData["MsgEdit"] = "Employee information Edited successfully";
                    return RedirectToAction("Index");
                }
            }

            return View("info");
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