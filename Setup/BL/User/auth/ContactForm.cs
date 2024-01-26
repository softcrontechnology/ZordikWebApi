using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Setup.BL.User.auth
{
    public class ContactForm : IContactForm
    {
        private readonly IConfiguration _configuration;

        private readonly DataAccessClass _dataAccessClass;

        public ContactForm(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<ContactFormResponse> SubmitContactForm (ContactFormRequest objRequest)
        {
            CommonResponse<ContactFormResponse> response = new CommonResponse<ContactFormResponse>();
            try
            {
                string mailbody = "Name : " + objRequest.FirstName + "\n Mobile : " + objRequest.Mobile + "\n Email : " + objRequest.Email + "\n Reason : " + objRequest.Message;
                string mailmessage = "Hi " + objRequest.FirstName + objRequest.LastName + ",\r\n\r\nThanks for contacting us we will contact you shortly.";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("aakashruhal1999@gmail.com", "Zordik India");
                mail.To.Add("aakashruhal99@gmail.com");
                mail.Subject = "Query sent by " + objRequest.FirstName + " On " + DateTime.Now;
                mail.Body = mailbody;
                MailMessage mail2 = new MailMessage();
                mail2.From = new MailAddress("aakashruhal1999@gmail.com", "Zordik India");
                mail2.To.Add(objRequest.Email);
                mail2.Subject = "Thank You For Contacting us";
                mail2.Body = mailmessage;

                bool mailSent = SendMail(mail);
                bool mail2Sent = SendMail(mail2);

                if (mailSent && mail2Sent)
                {
                    response.ResponseCode = 1;
                    response.ResponseMessage = "Form Submit Successfully";
                }
                else
                {
                    response.ResponseCode = 0;
                    response.ResponseMessage = "Form Not Submit. Try Again Later.";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 0;
                response.ResponseMessage = $"SMTP error: {ex.Message}";
            }
            return response;
        }


        private bool SendMail(MailMessage mail)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("aakashruhal1999@gmail.com", "spqb ffci nvkp smzq");

                    client.Send(mail);
                    return true; 
                }
            }
            catch (Exception)
            {
                return false; 
            }
        }
    }
}
