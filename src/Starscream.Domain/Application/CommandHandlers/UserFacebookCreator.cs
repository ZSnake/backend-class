using System;
using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;


namespace Starscream.Domain.Application.CommandHandlers
{
    public class UserFacebookCreator : ICommandHandler<CreateFacebookLoginUser>
    {
        readonly IWriteableRepository _writeableRepository;

        public UserFacebookCreator(IWriteableRepository writeableRepository)
        {
            _writeableRepository = writeableRepository;
        }

        public void Handle(IUserSession userIssuingCommand, CreateFacebookLoginUser command)
        {
            var userCreated = _writeableRepository.Create(new UserFacebookLogin(command.name,command.email,command.id,command.firstName,command.lastName,command.imageUrl,command.link));
            NotifyObservers(new UserFacebookCreated(userCreated.Id, command.email, command.name, command.id));
        }

        public event DomainEvent NotifyObservers;
    }
}