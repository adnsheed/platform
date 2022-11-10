namespace Platform.Core.Requests.Mail
{
    public static class EmailTemplate
    {
        public const string Subject = "Platform Credentials";
        public static string Template(string username, string password)
        {
            return $"<html><body>" +
                $"<p>Welcomet to the Platform.</p>" +
                $"<p>Your credentials are: <br/> " +
                $"Username: {username} <br/>" +
                $"Password: {password}</p>" +
                $"</body></html>";
        }
    }
}
