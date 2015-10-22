using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;


namespace Starscream.Domain.Application.CommandHandlers
{
    public  class EnablingUser : ICommandHandler<EnableUser>
    {
        readonly IWriteableRepository _writeableRepository;
        readonly IReadOnlyRepository _readOnlyRepository;

        public EnablingUser(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public void Handle(IUserSession userIssuingCommand, EnableUser command)
        {
            var user = _readOnlyRepository.GetById<User>(command.id);

            user.EnableUser();

            _writeableRepository.Update(user);

            NotifyObservers(new UserEnabled(user.Id));
        }

        public event DomainEvent NotifyObservers;
    }
}