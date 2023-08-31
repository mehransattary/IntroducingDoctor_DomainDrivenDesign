using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.DoctorInformationAgg.AddAddress;

public class AddAddress_DoctorInfo_Command_Validator: AbstractValidator<AddAddress_DoctorInfo_Command>
{
    public AddAddress_DoctorInfo_Command_Validator()
    {
        RuleFor(x => x.TextAddress).NotNull().NotEmpty().WithMessage(ValidationMessages.required("TextAddress")); 

    }
}

