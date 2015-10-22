using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;

namespace Starscream.Domain.Application.CommandHandlers
{
    public class UserProfileUpdater : ICommandHandler<UpdateUserProfile>
    {
        readonly IReadOnlyRepository _readonlyRepo;

        public UserProfileUpdater(IReadOnlyRepository readonlyRepo)
        {
            _readonlyRepo = readonlyRepo;
        }

        public void Handle(IUserSession userIssuingCommand, UpdateUserProfile command)
        {
            var user = _readonlyRepo.GetById<User>(command.Id);
            user.ChangeName(command.Name);
            user.ChangeEmailAddress(command.Email);
            NotifyObservers(new UserProfileUpdated(user.Id, command.Name, command.Email));
        }

        public event DomainEvent NotifyObservers;
    }
}