using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationtTest1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View();
            return Content("index");
            //return new EmptyResult();
            //return HttpNotFound();
        }
        public ActionResult TestMethod()
        {
            return Content("index TestMethod");
        }
        public ActionResult Info(int id)
        {
            return Content("Input " + id);
        }
        public ActionResult Info(int id, string name)
        {
            return Content("Input " + id + "Name "+name);
        }
        public ActionResult Data(int id, string name)
        {
            return Content("Input " + id + "Name " + name);
        }
    }
}