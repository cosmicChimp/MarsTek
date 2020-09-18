using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarsTek.Models;
using MarsTek.Dtos;
using System.Net.Mail;
using System.Net;

namespace MarsTek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMail)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("marrscoder@gmail.com");
                mail.To.Add("marrscoder@gmail.com");

                mail.Subject = sendMail.Subject;

                mail.IsBodyHtml = true;

                string content = "Name : " + sendMail.Name;
                content += "<br /> Message :" + sendMail.Message;

                mail.Body = content;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                NetworkCredential networkCredential = new NetworkCredential("marrscoder@gmail.com", "Skiing0709!");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);

                ViewBag.Message = "Message sent!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
