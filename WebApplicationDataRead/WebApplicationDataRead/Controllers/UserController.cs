﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDataRead.Context;

namespace WebApplicationDataRead.Controllers
{
    public class UserController : Controller
    {

        EmployeesEntities1 _dbContest = new EmployeesEntities1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            ModelState.Remove("RePassword");
            if (ModelState.IsValid)
            {
                var data = _dbContest.UserLogins.Where(x => x.Title == user.Title && x.Password == user.Password).FirstOrDefault(); 

                if (data != null)
                {
                    Session["Id"] = data.Id;
                    Session["Title"] = data.Title;
                    Session["Type"] = data.Type;

                    if (data.Type == "Admin" || data.Type == "Employee ")
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }

                ViewBag.Invalid = "Invalid username or password.";
                ModelState.Clear();
                return View();
            }

            return View();
        }

        [HttpGet]
        public ActionResult ClearLogout()
        {
            ModelState.Clear();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                if(_dbContest.UserLogins.Any(x => x.Title == user.Title))
                { 
                    ModelState.Clear();
                    Session.Clear();
                }
                _dbContest.UserLogins.Add(user);
                _dbContest.SaveChanges();
            }
            return View("Register");
        }
        public ActionResult Logout()
        {
            if(Session["Tital"] == null)
            return RedirectToAction("Login","User");
            
            ModelState.Clear();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}