using System;
using System.Net;
using System.Net.Mail;
using System.Web.Services;

namespace SoftLogic
{
    /// <summary>
    /// Summary description for SendEmail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SendEmail : System.Web.Services.WebService
    {
        [WebMethod]
        public void SensAcceptCode(string userEmail)
        {
            var fromAddress = new MailAddress("smtp123654@gmail.com", "SoftLogic");
            var toAddress = new MailAddress(userEmail, "Hi developer");

            const string password = "misha1qaz2wsx3edc";
            const string subject = "Accept account";

            Random random = new Random();

            int confirmationCode = random.Next(1, 1000);

            string body = $"Your confirmation Code:{ confirmationCode }";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };

            using (var massege = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(massege);
            }
        }
    }
}
