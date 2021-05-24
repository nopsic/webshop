using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Common
{
    public static class CommonMethods
    {
        public static string myKey = "$Łł93duirz{#8ke3";

        public static string EncryptPassword(string psw)
        {
            if (string.IsNullOrEmpty(psw))
            {
                return "";
            }

            psw += myKey;

            var pswBytes = Encoding.UTF8.GetBytes(psw);

            return Convert.ToBase64String(pswBytes);
        }

        public static string DecryptPassword(string encodedData)
        {
            if (string.IsNullOrEmpty(encodedData))
            {
                return "";
            }

            var encodedBytes = Convert.FromBase64String(encodedData);

            var decryptedPassword = Encoding.UTF8.GetString(encodedBytes);

            decryptedPassword = decryptedPassword.Substring(0, decryptedPassword.Length - myKey.Length);

            return decryptedPassword;
        }

        public static void SendEmail(Order[] orders)
        {
            var fromAddress = "szakdolgozatiemail@gmail.com";
            var toAddress = orders[0].Email;
            const string fromPassword = "Qwerty49";
            string subject = $"Order sent to the shop - #{orders[0].OrderNumber}";

            string body = $"Thank you for your order, {orders[0].FirstName} {orders[0].LastName}!\n\nYour order was placed with:\n\n";

            int total = 0;

            foreach (var item in orders)
            {
                body += $"Instrument: {item.InstrumentName}, Instrument Code: {item.Code}, Quantity: {item.Quantity}, Price: {item.Price.ToString("N0", new CultureInfo("hu-HU"))} Ft\n";
                total += item.Price;
            }
            body += $"\nTotal: {total.ToString("N0", new CultureInfo("hu-HU"))} Ft\n\nBest regards,\nWebshop team";

            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = fromAddress,
                    Password = fromPassword
                }
            };
            MailAddress FromEmail = new MailAddress(fromAddress, "Webshop");
            MailAddress ToEmail = new MailAddress(toAddress, orders[0].FirstName + " " + orders[0].LastName);

            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = subject,
                Body = body
            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
            }
            catch (Exception e)
            {
               
            }
        }
    }
}
