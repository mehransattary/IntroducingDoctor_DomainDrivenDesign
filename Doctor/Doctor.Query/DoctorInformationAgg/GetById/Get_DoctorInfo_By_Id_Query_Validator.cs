using Common.Application.Validation;
using Doctor.Query.MedicalServiceAgg.GetById;
using FluentValidation;

namespace Doctor.Query.DoctorInformationAgg.GetById;

public class Get_DoctorInfo_By_Id_Query_Validator : AbstractValidator<Get_DoctorInfo_By_Id_Query>
{

    public Get_DoctorInfo_By_Id_Query_Validator()
    {
        RuleFor(x => x.doctorInfoId).NotNull().WithMessage(ValidationMessages.required("DoctorinfoId"));
    }
}
