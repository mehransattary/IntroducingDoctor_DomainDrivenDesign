using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.VisitAgg.Create;

public class Create_VisitDay_Command_Validator:AbstractValidator<Create_VisitDay_Command>
{
    public Create_VisitDay_Command_Validator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(x => x.day).NotNull().NotEmpty().WithMessage(ValidationMessages.required("day"));

    }
}
