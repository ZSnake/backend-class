using Nancy.Security;

namespace Starscream.Web.Api.Infrastructure.Authentication
{
    public interface IApiUserMapper<in T>
    {
        IUserIdentity GetUserFromAccessToken(T token);
    }
}