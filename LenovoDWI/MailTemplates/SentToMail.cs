using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DWI_Application.MailTemplates
{
    public class SentToMail
    {
        private readonly IConfiguration _configuration;
        public SentToMail(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //public bool SentMail(string sMailTo, string subject, string body)
        //{
        //    string sMailFrom = "lenovodwi2020@gmail.com";
        //    MimeMessage message = new MimeMessage();
        //    MailboxAddress from = new MailboxAddress("DWI - Admin", sMailFrom);
        //    message.From.Add(from);

        //    MailboxAddress to = new MailboxAddress("User", sMailTo);
        //    message.To.Add(to);

        //    message.Subject = subject;

        //    BodyBuilder bodyBuilder = new BodyBuilder();
        //    bodyBuilder.HtmlBody = body;
        //    //bodyBuilder.TextBody = "Hello World!";

        //    message.Body = bodyBuilder.ToMessageBody();

        //    SmtpClient client = new SmtpClient();
        //    client.Connect("smtp.gmail.com", 465, true);
        //    client.Authenticate("lenovodwi2020@gmail.com", "mymistake123");

        //    client.Send(message);
        //    client.Disconnect(true);
        //    client.Dispose();

        //    return true;
        //}

        #region
        //public void SentMail(string sMailTo, string subject, string body)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();
        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //        message.From = new MailAddress("lenovodwi2020@gmail.com");
        //        message.To.Add(new MailAddress(sMailTo));
        //        message.Subject = subject;
        //        message.IsBodyHtml = true; //to make message body as html  
        //        message.Body = body;
        //        smtp.Port = 587;
        //        smtp.Host = "smtp.gmail.com"; //for gmail host  
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new NetworkCredential("lenovodwi2020@gmail.com", "mymistake123");
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.Send(message);
        //    }
        //    catch (Exception ex) {
        //        ex.Message.ToString();
        //    }
        //}
        #endregion

        #region private void SentMail(string fuction, string body)
        public void SentMail(string sMailTo, string subject, string body)
        {
            try
            {
                string HtmlBody = string.Empty;
                //string pathToFile = Path.Combine(_hostingEnvironment.ContentRootPath, "MailTemplates", "ExceptionTemplete.html");
                //using (StreamReader reader = new StreamReader(pathToFile))
                //{
                //    HtmlBody = reader.ReadToEnd();
                //}
                //HtmlBody = HtmlBody.Replace("{error}", body);
                MailMessage message = new MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                message.From = new MailAddress(_configuration.GetSection("EmailSettings:SMTPEmail").Get<string>());
                //string Toemail = _configuration.GetSection("EmailSettings:To_Email").Get<string>();
                //string[] ToMuliIds = Toemail.Split(',');
                //foreach (string ToEMailId in ToMuliIds)
                //{
                //    message.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id  
                //}
                message.To.Add(new MailAddress(sMailTo));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = body;
                smtp.Port = _configuration.GetSection("EmailSettings:Port").Get<int>();
                smtp.Host = _configuration.GetSection("EmailSettings:Host").Get<string>(); //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_configuration.GetSection("EmailSettings:SMTPEmail").Get<string>(),
                                                         _configuration.GetSection("EmailSettings:SMTPPassword").Get<string>());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

    }
}
