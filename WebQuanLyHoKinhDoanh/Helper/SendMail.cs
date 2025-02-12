using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebQuanLyHoKinhDoanh.Helper
{
    public class SendMail
    {
        public static bool SendEmail(string toEmail, string subject, string emailBody, string attachFile)
        {
            try
            {
                MailMessage msg = new MailMessage(ConstantHelper.emailSender, toEmail, subject, emailBody);
                using(var client = new SmtpClient(ConstantHelper.hostMail, ConstantHelper.portEMail))
                {
                    client.EnableSsl = true;
                    if(!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        msg.Attachments.Add(attachment);
                    }

                    NetworkCredential credentials = new NetworkCredential(ConstantHelper.emailSender, ConstantHelper.passwordSender);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;
                    client.Send(msg);
                } 
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}