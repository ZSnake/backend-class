using Starscream.Domain.Entities;

namespace Starscream.Domain.Services
{
    public interface IUserSessionFactory
    {
        UserLoginSession Create(User executor);
    }
}