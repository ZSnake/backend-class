using AcklenAvenue.Commands;
using Nancy;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;

using Starscream.Web.Api.Infrastructure.Authentication;
using Starscream.Web.Api.Infrastructure.Exceptions;
using Starscream.Web.Api.Modules;

namespace Starscream.Web.Api.Infrastructure
{
    public static class IdentityExtentions
    {
        public static IUserSession UserSession(this NancyModule module)
        {
            var user = module.Context.CurrentUser as LoggedInUserIdentity;
            if (user == null) throw new NoCurrentUserException();
            return user.UserSession;
        }

        public static UserLoginSession UserLoginSession(this NancyModule module)
        {
            var user = module.Context.CurrentUser as LoggedInUserIdentity;
            if (user == null || user.UserSession.GetType() != typeof(UserLoginSession)) throw new NoCurrentUserException();
            return (UserLoginSession) user.UserSession;
        }
    }
}