using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Starscream.Domain.Entities;

namespace Starscream.Data
{
    public class UserAutoMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasManyToMany<Role>(x => x.UserRoles).Cascade.All().Table("UsersRoles");
            mapping.HasManyToMany<UserAbility>(x => x.UserAbilities).Cascade.All().Table("UserAbilities");
        }
    }
}