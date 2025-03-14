using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationStart.Models;

namespace WebApplicationStart.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return Content("Student");
        }

        //[Route("student/date/{day}/{month:range(1,12)}/{year:regex(\\d{4}}")]
        //public ActionResult AdminssionDate(int day,int month,int year)
        //{
        //    return Content(day+"-"+month+"_"+year);
        //}
        public ActionResult ShowInfo()
        {
            var info = new Student() { Id = 1,name ="Jahid"};
            return View(info);
        }

    }
}