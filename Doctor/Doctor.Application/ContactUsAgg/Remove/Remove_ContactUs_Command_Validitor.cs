using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.ContactUsAgg.Remove;

public class Remove_ContactUs_Command_Validitor:AbstractValidator<Remove_ContactUs_Command>
{
    public Remove_ContactUs_Command_Validitor()
    {
        RuleFor(x => x.Id).NotNull().WithMessage(ValidationMessages.required("Id"));
    }
}
