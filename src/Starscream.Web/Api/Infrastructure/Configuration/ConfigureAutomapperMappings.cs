using System;
using AutoMapper;
using Autofac;
using Starscream.Domain.Entities;
using Starscream.Web.Api.Requests;
using Starscream.Web.Api.Responses.Admin;

namespace Starscream.Web.Api.Infrastructure.Configuration
{
    public class ConfigureAutomapperMappings : IBootstrapperTask<ContainerBuilder>
    {
        #region IBootstrapperTask<ContainerBuilder> Members

        public Action<ContainerBuilder> Task
        {
            get
            {
                return container =>
                    {
                        Mapper.CreateMap<User, AdminUserResponse>();
                        Mapper.CreateMap<UserAbility, UserAbilityRequest>().ReverseMap();
                    };
            }
        }

        #endregion
    }
}