using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.VisitAgg.EditTime;

public class EditTime_Command_Validator:AbstractValidator<EditTime_Command>
{
    public EditTime_Command_Validator()
    {
        RuleFor(x => x.StartTime).NotNull().NotEmpty().WithMessage(ValidationMessages.required("StartTime"));
        RuleFor(x => x.EndTime).NotNull().NotEmpty().WithMessage(ValidationMessages.required("EndTime"));
        RuleFor(x => x.VisitDayId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("VisitDayId"));
    }
}
