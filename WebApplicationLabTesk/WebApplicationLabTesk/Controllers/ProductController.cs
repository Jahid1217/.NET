using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLabTesk.Models;

namespace WebApplicationLabTesk.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            int totalprice = 0;
            
            var p1 = new Product()
            {
                ID = 1,
                ProductName = "Laptop",
                ProductCatagory = "Hp",
                ProductPrice = 250000,
                ProductQuantity = 5,
                
                
               
            };
            var p2 = new Product()
            {
                ID = 2,
                ProductName = "PC",
                ProductCatagory = "Lenovo",
                ProductPrice = 25000,
                ProductQuantity = 3,
                
            };
           
            var productlist = new List<Product>() {  p1, p2 };
            return View(productlist);
        }
    }
}