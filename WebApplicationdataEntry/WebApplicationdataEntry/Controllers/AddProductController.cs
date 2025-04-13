using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationdataEntry.Context;

namespace WebApplicationdataEntry.Controllers
{
    public class AddProductController : Controller
    {
        // GET: AddProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult ProductDetails(Product prd)
        {
            return View("AddProduct");
            return Content("Employee Added Successfully");
        }
    }
}