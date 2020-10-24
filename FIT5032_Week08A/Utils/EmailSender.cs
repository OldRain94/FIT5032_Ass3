using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {           
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("zhuangkaiqi@foxmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var bytes = File.ReadAllBytes("C:\\Users\\NEW\\Desktop\\5032\\Assignment 3\\test.txt");
            var file = Convert.ToBase64String(bytes);

            msg.AddAttachment("file.txt",file);

            var response = client.SendEmailAsync(msg);
        }

       

    }
}