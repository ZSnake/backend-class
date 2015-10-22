using System;
using System.Collections.Generic;
using Starscream.Web.Api.Modules;

namespace Starscream.Web.Api.Requests
{
    public class UserAbilitiesRequest
    {
        public IEnumerable<UserAbilityRequest> Abilities { get; set; }
        public Guid UserId { get; set; }
    }
}