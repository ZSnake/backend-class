using System;
using AcklenAvenue.Commands;
using Starscream.Domain.Services;


namespace Starscream.Domain
{
    public class VisitorSession : IUserSession
    {
        #region IUserSession Members

        public Guid Id { get; private set; }

        #endregion
    }
}