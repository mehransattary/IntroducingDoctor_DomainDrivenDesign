using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.VisitAgg.Edit;

public class Edit_VisitDay_Command_Validator:AbstractValidator<Edit_VisitDay_Command>
{
    public Edit_VisitDay_Command_Validator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));

        RuleFor(x => x.day).NotNull().NotEmpty().WithMessage(ValidationMessages.required("day"));

    }
}
