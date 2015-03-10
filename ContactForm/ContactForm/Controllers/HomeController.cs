using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           // Models.ContactForm contactForm = new Models.ContactForm();
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
            //mail us a copy
            //SMTP: Simple Mail Transfer Protocol
            //host:mail.dustinkraft.com
            //port 587
            //user: postmaster@dustinkraft.com
        //password: techIsFun1
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

          //  MailMessage mail = new MailMessage();
          //  mail.From = new MailAddress("the_robots@seedpaths.com");

         //  SmtpClient client = new SmtpClient("mail.dustinkraft.com");
         //  client.Port = 587;
         //  client.Host = "mail.dustinkraft.com";
         //  client.EnableSsl = true;
         //  client.Timeout = 10000;
         //  client.DeliveryMethod = SmtpDeliveryMethod.Network;
         //  client.UseDefaultCredentials = false;
         //  client.Credentials = new System.Net.NetworkCredential("postmaster@dustinkratft.com", "techIsFun1"); 

          // client.Send(mail); 

             SmtpServer.Send(mail);

           //SmtpServer.Send(mail);

            // redirect thhe user to the thank you page
        return RedirectToAction("ThankYou", "Home");
    }
        public ActionResult ThankYou() { return View(); }

    }
}