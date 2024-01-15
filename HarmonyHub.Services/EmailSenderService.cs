using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services
{
	public class EmailSenderService : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			await Execute(subject, htmlMessage, email);
		}

		public async Task Execute(string subject, string message, string toEmail)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential("regal.noreply@gmail.com", "pmku swlr xlxc qcwq");

			MailMessage mailMessage = new MailMessage();
			mailMessage.From = new MailAddress("regal.noreply@gmail.com");
			mailMessage.To.Add(toEmail);
			mailMessage.Subject = subject;
			mailMessage.Body = message;
			await client.SendMailAsync(mailMessage);
		}
	}
}
