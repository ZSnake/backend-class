using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.DomainEvents;
using Starscream.Domain.Entities;
using Starscream.Domain.Services;


namespace Starscream.Domain.Application.CommandHandlers
{
    public class PasswordResetter : ICommandHandler<ResetPassword>
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteableRepository _writeableRepository;

        public PasswordResetter(IReadOnlyRepository readOnlyRepository, IWriteableRepository writeableRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeableRepository = writeableRepository;
        }

        public void Handle(IUserSession userIssuingCommand, ResetPassword command)
        {
            var passwordResetToken = _readOnlyRepository.GetById<PasswordResetAuthorization>(command.ResetPasswordToken);
            var user = _readOnlyRepository.GetById<UserEmailLogin>(passwordResetToken.UserId);
            user.ChangePassword(command.EncryptedPassword);
            _writeableRepository.Update(user);
            _writeableRepository.Delete<PasswordResetAuthorization>(command.ResetPasswordToken);
            NotifyObservers(new PasswordReset(passwordResetToken.UserId));
        }

        public event DomainEvent NotifyObservers;
    }
}