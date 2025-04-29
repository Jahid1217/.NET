using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationStudentInformation.Context;

namespace WebApplicationStudentInformation.Controllers
{
    public class StudentController : Controller
    {
        StudentInfoEntities _dbContext = new StudentInfoEntities();
        // GET: Student

        public ActionResult Index()
        {

            var students = _dbContext.Student_Table.ToList();
            return View(students);
        }
        public ActionResult StandardHelper()
        {
            return View();
        }
        public ActionResult StandardHelperStudent(Student_Table student)
        {
            if (ModelState.IsValid) 
            { 
                _dbContext.Student_Table.Add(student);
                _dbContext.SaveChanges();
                TempData["Success"] = "Student added successfully.";
                return RedirectToAction("Index");
            }
            return View("StandardHelper", student);
        }

        public ActionResult StronglyTypedHelper()
        {
            return View();
        }
        public ActionResult StronglyTypedHelperStudent(Student_Table student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Student_Table.Add(student);
                _dbContext.SaveChanges();
                TempData["Success"] = "Student added successfully.";
                return RedirectToAction("Index");
            }
            return View("StronglyTypedHelper", student);
        }

        public ActionResult TemplatedHelper()
        {
            return View();
        }
        public ActionResult TemplatedHelperStudent(Student_Table student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Student_Table.Add(student);
                _dbContext.SaveChanges();
                TempData["Success"] = "Student added successfully.";
                return RedirectToAction("Index");
            }
            return View("TemplatedHelper", student);
        }

    }
}