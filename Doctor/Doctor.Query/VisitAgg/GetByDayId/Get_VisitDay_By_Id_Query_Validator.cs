using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Query.VisitAgg.GetByDayId;

public class Get_VisitDay_By_Id_Query_Validator:AbstractValidator<Get_VisitDay_By_Id_Query>
{
    public Get_VisitDay_By_Id_Query_Validator()
    {
        RuleFor(x => x.visitDayId).NotNull().WithMessage(ValidationMessages.required("visitDayId"));
    }
}
