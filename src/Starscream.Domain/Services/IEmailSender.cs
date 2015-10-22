namespace Starscream.Domain.Services
{
    public interface IEmailSender
    {
        void Send<T>(string emailAddress, T emailModel);
    }
}