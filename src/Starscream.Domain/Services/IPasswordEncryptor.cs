using Starscream.Domain.ValueObjects;

namespace Starscream.Domain.Services
{
    public interface IPasswordEncryptor
    {
        EncryptedPassword Encrypt(string clearTextPassword);
    }
}