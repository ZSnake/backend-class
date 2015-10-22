using System;

namespace Starscream.Domain.Services
{
    public class GuidIdentityGenerator : IIdentityGenerator<Guid>
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}