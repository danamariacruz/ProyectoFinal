using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class CorreoController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string receptor, string asunto, string mensaje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderemail = new MailAddress("danacruzpaulini@gmail.com", "Enviar");
                    var receivermail = new MailAddress(receptor, "Receptor");

                    var contraseña = "danacruz";
                    var sub = asunto;
                    var body = mensaje;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, contraseña)

                    };

                    using (var mess = new MailMessage(senderemail, receivermail)
                    {
                        Subject = asunto,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }

                    return RedirectToAction("Ventas", "Store");
                }

            }
            catch (Exception)
            {
                ViewBag.Error = "Hay algunos problemas con el envio";
            }

                return RedirectToAction("Ventas", "Store");
        }
    }
}