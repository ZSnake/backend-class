using System;

namespace Starscream.Domain.Services
{
    public interface ITimeProvider
    {
        DateTime Now();
    }
}