using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;


namespace Starscream.Domain.Application.CommandHandlers
{
    public class UserEmailCreator : ICommandHandler<CreateEmailLoginUser>
    {
        readonly IWriteableRepository _writeableRepository;
        private readonly IReadOnlyRepository _readOnlyRepository;

        public UserEmailCreator(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        #region ICommandHandler Members

        public void Handle(IUserSession userIssuingCommand, CreateEmailLoginUser command)
        {
            var userCreated = new UserEmailLogin(command.Name, command.Email, command.EncryptedPassword,
                command.PhoneNumber);

            command.abilities.ToList().ForEach(x => userCreated.AddAbility(_readOnlyRepository.GetById<UserAbility>(x.Id)));

            var userSaved = _writeableRepository.Create(userCreated);

            NotifyObservers(new UserEmailCreated(userSaved.Id, command.Email, command.Name, command.PhoneNumber));
        }

        public event DomainEvent NotifyObservers;

        #endregion
    }
}