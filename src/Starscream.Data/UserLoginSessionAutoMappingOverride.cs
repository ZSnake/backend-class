using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Starscream.Domain.Entities;

namespace Starscream.Data
{
    public class UserLoginSessionAutoMappingOverride : IAutoMappingOverride<UserLoginSession>
    {
        public void Override(AutoMapping<UserLoginSession> mapping)
        {            
        }
    }
}