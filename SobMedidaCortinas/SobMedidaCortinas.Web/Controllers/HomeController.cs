using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SendGrid;
using SendGrid.Helpers.Mail;
using SobMedidaCortinas.Web.Models;

namespace SobMedidaCortinas.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeModel());
        }
    }

    public class ContatoController : Controller
    {

        [HttpPost]
        public async Task<ActionResult> Index(ContactModel request)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
#if !DEBUG
                if (!(await IsCaptchaValid(HttpContext.Request.Form.Get("g-recaptcha-response"))))
                {
                    Response.StatusCode = 400;
                    return Content("invalidCaptcha");
                }
#endif

                await SendEmailAsync(request);
                return Json("ok");
            }
            catch (SendEmailException ex)
            {
                return Json("emailFailed");
            }
            catch (Exception ex)
            {
                request.Mensagem += "\r\n=======CAPTCHA FALHOU=======\r\n" + ex.ToString();

                await SendEmailAsync(request);
                return Json("ok");
            }
        }

        private async Task<bool> IsCaptchaValid(string gCaptchaResponse)
        {
            JObject captchaResponse = null;
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"secret", "6Lfg8x4TAAAAAGSeTQicTou8gE8OtT42yd883Pgv"},
                    {"response", gCaptchaResponse},
                    {"remoteip", HttpContext.Request.UserHostAddress}
                };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                captchaResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            }

            if (captchaResponse == null || (bool)captchaResponse["success"] == false)
            {
                return false;
            }
            return true;
        }

        private async Task SendEmailAsync(ContactModel contactData)
        {
            try
            {
                string plainTextContent = String.Format("PEDIDO DE ORÇAMENTO\r\n\r\nNome: {0}\r\n Telefone: {1}\r\n E-mail: {2}\r\n Bairro: {3}\r\n Mensagem: {4}\r\n", contactData.Nome, contactData.Telefone, contactData.Email, contactData.Bairro, contactData.Mensagem);
                string htmlContent = $"<html><body>{plainTextContent.Replace("\r\n", "<br/>")}</body></html>";

                var client = new SendGridClient(@""); // TODO: Get from env var
                
                var message = MailHelper.CreateSingleEmail(new EmailAddress("thiago@april9.com.au"), new EmailAddress("ana@sobmedidacortinas.com.br"), "PO (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")", plainTextContent, htmlContent);
                message.SetReplyTo(new EmailAddress(contactData.Email, contactData.Nome));
                message.AddBccs(new List<EmailAddress> { new EmailAddress("thiagopxp@gmail.com") });

                var res = await client.SendEmailAsync(message);

                if (!res.IsSuccessStatusCode)
                {
                    string body = await res.Body.ReadAsStringAsync();
                    throw new SendEmailException($"Failed to send message ({res.StatusCode}: {body}");
                }
            }
            catch (Exception ex)
            {
                throw new SendEmailException("Failed to send email", ex);
            }
        }

        public class SendEmailException : Exception
        {
            public SendEmailException()
            {
            }

            public SendEmailException(string message) : base(message)
            {
            }

            public SendEmailException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected SendEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        //private void SendEmail_Mailgun(ContactModel contactData)
        //{
        //    RestClient client = new RestClient();
        //    client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        //    client.Authenticator =
        //            new HttpBasicAuthenticator("api", "key-61xosbm9be2g2ir0wt2vijskjrteavj7");
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", "sobmedidacortinas.com.br", ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", String.Format("{0} via SobMedidaCortinas <mailgun@sobmedidacortinas.com.br>", contactData.Nome));
        //    request.AddParameter("to", "ana@sobmedidacortinas.com.br");
        //    request.AddParameter("bcc", "thiagopxp@gmail.com");
        //    request.AddParameter("h:Reply-To", String.Format("{0} <{1}>", contactData.Nome, contactData.Email));
        //    request.AddParameter("subject", "PO (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")");
        //    request.AddParameter("text", String.Format("PEDIDO DE ORÇAMENTO\n\r\n\rNome: {0}\n\r Telefone: {1}\n\r E-mail: {2}\n\r Bairro: {3}\n\r Mensagem: {4}\n\r", contactData.Nome, contactData.Telefone, contactData.Email, contactData.Bairro, contactData.Mensagem));
        //    request.Method = Method.POST;
        //    client.Execute(request);
        //}
    }

    public class ContactModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public string Bairro { get; set; }
    }
}