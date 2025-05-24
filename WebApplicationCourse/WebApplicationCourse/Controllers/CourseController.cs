using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCourse.Context;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class CourseController : Controller
    {
        Model1 db = new Model1();
        // GET: Course
        public ActionResult Index()
        {
            var date = db.Courses.ToList();
            return View(date);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(db.Categories, "type");
            return View();
            
        }
        [HttpPost]
        public ActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "type", model.Category);
            return View("Index");
        }
    }
}
