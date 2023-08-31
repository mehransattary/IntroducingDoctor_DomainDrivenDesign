using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.DoctorInformationAgg.AddContactNumber;

public class AddContactNumber_DoctorInfo_Command_Validator:AbstractValidator<AddContactNumber_DoctorInfo_Command>
{
    public AddContactNumber_DoctorInfo_Command_Validator()
    {
        RuleFor(x => x.Mobile).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Mobile"));

    }
}
