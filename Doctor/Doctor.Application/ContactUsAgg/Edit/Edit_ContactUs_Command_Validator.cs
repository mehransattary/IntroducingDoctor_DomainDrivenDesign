using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.ContactUsAgg.Edit;

public class Edit_ContactUs_Command_Validator: AbstractValidator<Edit_ContactUs_Command>
{
    public Edit_ContactUs_Command_Validator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(x => x.ImageFile).NotNull().NotEmpty().WithMessage(ValidationMessages.required("ImageFile")).JustImageFile();
    }
}
