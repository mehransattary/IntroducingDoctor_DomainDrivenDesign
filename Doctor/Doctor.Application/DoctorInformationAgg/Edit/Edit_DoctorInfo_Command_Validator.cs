using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using Doctor.Domain.DoctorInformationAgg;
using FluentValidation;

namespace Doctor.Application.DoctorInformationAgg.Edit;

public class Edit_DoctorInfo_Command_Validator:AbstractValidator<Edit_DoctorInfo_Command>
{
    public Edit_DoctorInfo_Command_Validator()
    {
        RuleFor(x => x.fullName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("fullName"));

        RuleFor(x => x.fileImage).NotNull().NotEmpty().WithMessage(ValidationMessages.required("fileImage")).JustImageFile();
    }
}
