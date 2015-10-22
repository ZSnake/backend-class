using System;

namespace Starscream.Domain.Exceptions
{
    public class DisableUserAccountException : Exception
    {
         public DisableUserAccountException()
             : base("Your account has been disabled. Please contact your administrator for help.")
        {
        }
    }
}