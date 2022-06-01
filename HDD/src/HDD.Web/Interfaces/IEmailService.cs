namespace HDD.Web.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string email, string subject, string message, bool html);
        void SendEmail(string fromEmail, string email, string subject, string message, bool html);
        void SendException(Exception ex, string subject);
    }
}
