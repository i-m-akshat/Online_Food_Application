using BLL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Options;

namespace BLL.Implementation
{
    public class SendMailDao : SendMailDAO
    {
        private readonly MailSettings _mailSettings;

        //Constructor of sendMailDao
        public SendMailDao(MailSettings mailSettings)
        {
            _mailSettings=mailSettings;
        }
        public async Task<bool> SendMailAsync(Email mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject=mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachment != null)
            {
                byte[] fileBytes;
                foreach(var file in mailRequest.Attachment)
                {
                    if (file.Length>0)
                    {
                        using (var ms=new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes=ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                     }
                }
            }
            builder.HtmlBody=mailRequest.Body;
                email.Body=builder.ToMessageBody();
                using var smtp=new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
             
            return true;
        }
       
    }
}
