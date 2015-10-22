using System;
using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;


namespace Starscream.Domain.Application.CommandHandlers
{
    public  class DisablingUser : ICommandHandler<DisableUser>
    {
        public IWriteableRepository writeableRepository { get; private set; }
        public IReadOnlyRepository readOnlyRepository { get; private set; }

        public DisablingUser(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository)
        {
            this.writeableRepository = writeableRepository;
            this.readOnlyRepository = readOnlyRepository;
        }

        public void Handle(IUserSession userIssuingCommand, DisableUser command)
        {
            var user = readOnlyRepository.GetById<User>(command.id);
            user.DisableUser();

            writeableRepository.Update(user);

            NotifyObservers(new UserDisabled(user.Id));


        }

        public event DomainEvent NotifyObservers;
    }
}