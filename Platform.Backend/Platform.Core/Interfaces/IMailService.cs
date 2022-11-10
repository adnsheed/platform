namespace Platform.Core.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmail(string toEmail, string subject, string content);
    }
}
