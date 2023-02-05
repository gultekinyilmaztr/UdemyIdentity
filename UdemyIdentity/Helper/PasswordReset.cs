using System;
using System.Net.Mail;

namespace UdemyIdentity.Helper
{
    public static class PasswordReset
    {
        public static void PasswordResetSendEmail(string link,string email)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("gultetekinyilmaztr@gmail.com");
            mail.To.Add(email);

            mail.Subject = $"www.bıdıbı.com::Şifre sıfırlama";
            mail.Body = "<h2>Şifrenizi yenilemek için lütfen aşağıdaki linke tıklayınız.</h2><hr/>";
            mail.Body += $"<a href='{link}'>şifre yenileme linki</a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("\"gultetekinyilmaztr@gmail.com", "gultekin10");

            smtpClient.Send(mail);

        }
    }
}
