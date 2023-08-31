using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using Doctor.Domain.DoctorInformationAgg;
using FluentValidation;

namespace Doctor.Application.DoctorInformationAgg.Create;

public class Create_DoctorInfo_Command_Validator : AbstractValidator<Create_DoctorInfo_Command>
{
    public Create_DoctorInfo_Command_Validator()
    {
        RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("fullName"));

        RuleFor(x => x.FileImage).NotNull().NotEmpty().WithMessage(ValidationMessages.required("FileImage")).JustImageFile();

    }
}
