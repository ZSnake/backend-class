namespace Starscream.Domain.Services
{
    public interface IIdentityGenerator<out T>
    {
        T Generate();
    }
}