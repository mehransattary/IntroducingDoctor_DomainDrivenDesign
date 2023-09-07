﻿using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.UserAgg.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(r => r.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("ایمیل نامعتبر است");


        RuleFor(f => f.Avatar)
            .JustImageFile();
    }
}