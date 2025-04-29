using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationStudentInfo.Context;

namespace WebApplicationStudentInfo.Controllers
{
    public class StudentController : Controller
    {
      // Student_DB_InfoEntities db = new Student_DB_InfoEntities();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StandardHelper()
        {
            return View();
        }
        public ActionResult StandardHelperUpdate(Student_DB stu)
        {
            return View("StandardHelper",stu);
        }
        public ActionResult StronglyTypedHelper()
        {
            return View();
        }
        public ActionResult StronglyTypedHelperUpdate(Student_DB stu)
        {
            return View("StronglyTypedHelper",stu);
        }
        public ActionResult TemplatedHelper()
        {
            return View();
        }
        public ActionResult TemplatedHelperUpdate(Student_DB stu)
        {
            return View("TemplatedHelper",stu);
        }
    }
}