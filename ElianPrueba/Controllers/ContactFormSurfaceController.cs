using System.Web.Mvc;
using Umbraco.Web.Mvc;
using ElianPrueba.Models;
using System.Net.Mail;

namespace ElianPrueba.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new contactformViewModel());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(contactformViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            //send email
            MailMessage message = new MailMessage();
            message.To.Add("ecruz@fintech.do");
            message.Subject = "New Contact request";
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;
            SmtpClient smtp = new SmtpClient();
            //smtp.Send(message);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}