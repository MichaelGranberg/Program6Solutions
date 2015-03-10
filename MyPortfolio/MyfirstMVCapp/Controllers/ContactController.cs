using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace MyfirstMvcapp.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.ContactForm());
        }
       
       
        [HttpPost]
        public ActionResult Contact(Models.ContactForm contactForm)
        {
            //add the form to the database


            try
            {
                //try/ Catch : try doing something 

                // step 1: create the data context
                contactForm.ContactDate = DateTime.Now;
                Models.ContactFormEntities db = new Models.ContactFormEntities();
                // step 2: add the object to the table
                db.ContactForms.Add(contactForm);
                // step 3: save
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                // if it blows up..  
                ViewBag.Error = ex.Message;
                return View("Error");

            }

            MailMessage mail = new MailMessage();
            //who its from... 
            mail.From = new MailAddress("the_robots@seedpaths.com");
            //send it to... 
            mail.To.Add("mdgranberg@gmail.com");
            mail.Subject = "Contact message from " + contactForm.ContactName;
            mail.Body = string.Format("{0} at {1} says: {2}", contactForm.ContactName, contactForm.ContactEmailID, contactForm.ContactMessage);


            //connecting to the actual email server 
            SmtpClient SmtpServer = new SmtpClient("mail.dustinkraft.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");

            SmtpServer.Send(mail);


            // redirect thhe user to the thank you page
            return RedirectToAction("ThankYou", "Contact");
        }
        public ActionResult ThankYou() { return View(); }

    }
}