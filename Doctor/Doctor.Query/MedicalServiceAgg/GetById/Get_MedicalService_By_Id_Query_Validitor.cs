

using Common.Application.Validation;
using Doctor.Domain.MedicalServicesAgg;
using FluentValidation;

namespace Doctor.Query.MedicalServiceAgg.GetById;

public class Get_MedicalService_By_Id_Query_Validitor:AbstractValidator<Get_MedicalService_By_Id_Query>
{
    public Get_MedicalService_By_Id_Query_Validitor()
    {
        RuleFor(x => x.medicalServiceId).NotNull().WithMessage(ValidationMessages.required("medicalServiceId"));
    }
}
