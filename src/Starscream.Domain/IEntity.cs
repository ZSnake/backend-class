using System;

namespace Starscream.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}