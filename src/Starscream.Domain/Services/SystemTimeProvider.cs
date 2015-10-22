using System;

namespace Starscream.Domain.Services
{
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}