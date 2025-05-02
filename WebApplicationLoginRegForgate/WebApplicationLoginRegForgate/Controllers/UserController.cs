using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplicationLoginRegForgate.Context;

namespace WebApplicationLoginRegForgate.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "IsEmailVerified, ActivationCode")] RegistrationInfo registrationInfo)
        {
            bool Status = false;
            string message = "";
            // model Validation
            if (ModelState.IsValid)
            {

                //Emai1 is already Exist
                var isExist = IsEmailExist(registrationInfo.Email);
                if (isExist) {
                    ModelState.AddModelError("EmailExist", "Email already exists");
                    return View(registrationInfo);
                }
                // Generate Activation Code
                registrationInfo.ActivationCode = Guid.NewGuid();
                // Password Hashing
                registrationInfo.Password = Crpto.Hash(registrationInfo.Password);
                registrationInfo.IsEmailVerified = false;
                //Save data to Database
                using (BookShopEntities BS = new BookShopEntities())
                {
                    BS.RegistrationInfoes.Add(registrationInfo);

                    BS.SaveChanges();
                
                    SendVerifications(registrationInfo.Email, registrationInfo.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link has been sent to your email address.";
                    Status = true;
                }
                //Send Email to User


            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.message = message;
            ViewBag.Status = Status;
            return View(registrationInfo);
        }
        [NonAction]

        public bool IsEmailExist(string email)
        {
            using (BookShopEntities BS = new BookShopEntities())
            {
                var v = BS.RegistrationInfoes.Where(a => a.Email == email).FirstOrDefault();
                return v != null;
            }
        }
        [NonAction]
        public void SendVerifications(string email, string activationVode)
        {
            //var schema = Request.Url.Scheme;
            //var host = Request.Url.Host;
            //var port = Request.Url.Port;

            //string url = schema + "://" + host + ":" + port + "/User/VerifyAccount/" + activationVode;

            var verificationLink = "/User/VerifyAccount/" + activationVode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verificationLink);
            var formEmail = new MailAddress("jahid.hasan1217@gmail.com", "Someone");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "rpxx iroi vvov auor"; 
            string subject = "Your account is successfully created";
            string body = "<br/><br/>We are excited to tell you that your account is successfully created. Please click on the below link to verify your account" +
                "<br/><br/><a href='" + verificationLink + "'>" + verificationLink + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(formEmail.Address, fromEmailPassword)
            };

            using(var message = new MailMessage(formEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}