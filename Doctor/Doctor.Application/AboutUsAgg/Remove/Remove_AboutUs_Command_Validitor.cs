using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.AboutUsAgg.Remove;

public class Remove_AboutUs_Command_Validitor:AbstractValidator<Remove_AboutUs_Command>
{
    public Remove_AboutUs_Command_Validitor()
    {
        RuleFor(x => x.Id).NotNull().WithMessage(ValidationMessages.required("Id"));
    }
}
