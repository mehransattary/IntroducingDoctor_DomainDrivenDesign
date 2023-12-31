﻿using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.AboutUsAgg.Edit;

public class Edit_AboutUs_Command_Validator: AbstractValidator<Edit_AboutUs_Command>
{
    public Edit_AboutUs_Command_Validator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(x => x.ImageFile).NotNull().NotEmpty().WithMessage(ValidationMessages.required("ImageFile")).JustImageFile();
    }
}
