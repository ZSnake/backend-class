﻿using System;
using System.Collections.Generic;
using System.Linq;
using AcklenAvenue.Commands;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.Entities;
using Starscream.Domain.Exceptions;
using Starscream.Domain.Services;


namespace Starscream.Domain.Validators
{
    public class PassowrdResetValidator : ICommandValidator<ResetPassword>
    {
        readonly IReadOnlyRepository _readOnlyRepo;
        readonly ITimeProvider _timeProvider;

        public PassowrdResetValidator(IReadOnlyRepository readOnlyRepo, ITimeProvider timeProvider)
        {
            _readOnlyRepo = readOnlyRepo;
            _timeProvider = timeProvider;
        }

        public void Validate(IUserSession userSession, ResetPassword command)
        {
            var failures = new List<ValidationFailure>();
            if (command.EncryptedPassword==null || string.IsNullOrEmpty(command.EncryptedPassword.Password))
            {
                failures.Add(new ValidationFailure("EncryptedPassword", ValidationFailureType.Missing));
            }
            if (command.ResetPasswordToken == Guid.Empty)
            {
                failures.Add(new ValidationFailure("ResetPasswordToken", ValidationFailureType.Missing));
            }
            else
            {
                try
                {
                    var passwordResetToken = _readOnlyRepo.GetById<PasswordResetAuthorization>(command.ResetPasswordToken);

                    if (passwordResetToken.Created > _timeProvider.Now().AddDays(2))
                    {
                        failures.Add(new ValidationFailure("ResetPasswordToken", ValidationFailureType.Expired));
                    }
                }
                catch (ItemNotFoundException<PasswordResetAuthorization>)
                {
                    failures.Add(new ValidationFailure("ResetPasswordToken", ValidationFailureType.DoesNotExist));
                }
            }
            if (failures.Any())
                throw new CommandValidationException(failures);
        }
    }
}