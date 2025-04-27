using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationStudentSystem.Context;

namespace WebApplicationStudentSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        StudentDBEntities _dbStudentContext = new StudentDBEntities();
        // GET: StudentInfomation
        public ActionResult Index()
        {
            var date = _dbStudentContext.StudentsInformations.ToList();
            return View(date);
        }
        public ActionResult StandardHelperStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StandardHelperStudentSave(StudentsInformation StuInfo)
        {
            if (ModelState.IsValid)
            {
                _dbStudentContext.StudentsInformations.Add(StuInfo);
                _dbStudentContext.SaveChanges();
                TempData["Success"] = "Student Added Successfully";
                return RedirectToAction("Index");
            }
            return View("StandardHelperStudent", StuInfo);
        }
        public ActionResult StronglyTypedHelper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StronglyTypedHelperStudentSave(StudentsInformation StuInfo)
        {
            if (ModelState.IsValid)
            {
                _dbStudentContext.StudentsInformations.Add(StuInfo);
                _dbStudentContext.SaveChanges();
                TempData["Success"] = "Student Added Successfully";
                return RedirectToAction("Index");
            }
            return View("StronglyTypedHelper", StuInfo);
        }
        public ActionResult TemplatedHelper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TemplatedHelperStudentSave(StudentsInformation StuInfo)
        {
            if (ModelState.IsValid)
            {
                _dbStudentContext.StudentsInformations.Add(StuInfo);
                _dbStudentContext.SaveChanges();
                TempData["Success"] = "Student Added Successfully";
                return RedirectToAction("Index");
            }
            return View("TemplatedHelper", StuInfo);
        }
    }
}