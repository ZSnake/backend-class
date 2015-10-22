using System;

namespace Starscream.Domain.Services
{
    public interface ITokenExpirationProvider
    {
        DateTime GetExpiration(DateTime now);
    }
}