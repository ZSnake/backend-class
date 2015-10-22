using System;
using Starscream.Domain.Entities;
using Starscream.Domain.ValueObjects;

namespace Starscream.Domain.Specs.Stubs
{
    public class TestUser : UserEmailLogin
    {
        public TestUser(Guid userId, string name, string password)
        {
            Id = userId;
            Name = name;
            this.EncryptedPassword = password;
        }
    }
}