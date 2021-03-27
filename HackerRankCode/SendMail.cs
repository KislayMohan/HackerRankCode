using System.Net;
using System.Net.Mail;

namespace HackerRankCode
{
    public class SendMail
    {
        public void SendEmail()
        {
            var body = "<html><div>Click <a href=\"ocbcpao://billsplit?trans=sa12332q\">here</a> to access the app</div></html>";
            MailMessage mail = new MailMessage("smashingkis143@gmail.com", "mkislay@yahoo.com")
            {
                Subject = "test mail",
                Body = body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };
            SmtpClient smtpmail = new SmtpClient
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("smashingkis143@gmail.com", "L@mborgh1n!")
            };
            smtpmail.Send(mail);
        }
    }
}
