using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.ContactUsAgg.Create;

public class Create_ContactUs_Command_Validator:AbstractValidator<Create_ContactUs_Command>
{
    public Create_ContactUs_Command_Validator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(x => x.ImageFile).NotNull().NotEmpty().WithMessage(ValidationMessages.required("ImageFile")).JustImageFile();
    }
}
