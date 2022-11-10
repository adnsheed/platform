using Platform.Core.Interfaces;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace Platform.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> SendEmail(string toEmail, string subject, string content)
        {
            var apiKey = configuration["SendGrid:Key"];

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(configuration["SendGrid:Email"]);

            var to = new EmailAddress(toEmail);
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);

            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
