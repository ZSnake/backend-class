﻿using System;
using System.Collections.Generic;
using AcklenAvenue.Commands;
using Machine.Specifications;
using Moq;
using Starscream.Domain.Application.Commands;
using Starscream.Domain.Exceptions;
using Starscream.Domain.Services;
using Starscream.Domain.Validators;

using It = Machine.Specifications.It;

namespace Starscream.Domain.Specs.Validation
{
    public class when_validating_an_invalid_password_reset_command
    {
        static ICommandValidator<ResetPassword> _validator;
        static List<ValidationFailure> _expectedFailures;
        static Exception _exception;

        Establish context =
            () =>
            {
                _validator = new PassowrdResetValidator(Mock.Of<IReadOnlyRepository>(), Mock.Of<ITimeProvider>());

                _expectedFailures = new List<ValidationFailure>
                                    {
                                        new ValidationFailure(
                                            "EncryptedPassword",
                                            ValidationFailureType.Missing),
                                        new ValidationFailure(
                                            "ResetPasswordToken",
                                            ValidationFailureType.Missing)
                                    };
            };

        Because of =
            () => _exception = Catch.Exception(() =>
                _validator.Validate(new VisitorSession(),
                    new ResetPassword(Guid.Empty, null)));

        It should_return_expected_failures =
            () => ((CommandValidationException) _exception).ValidationFailures.ShouldBeLike(_expectedFailures);
    }
}