using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.MedicalServiceAgg.Create;

public class Create_MedicalService_Command_Validator : AbstractValidator<Create_MedicalService_Command>
{
    public Create_MedicalService_Command_Validator()
    {
        RuleFor(x => x.title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
        RuleFor(x => x.shortDescription).NotNull().NotEmpty().WithMessage(ValidationMessages.required("توضیح کوتاه"));
        RuleFor(x => x.ImageFile).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
    }
}
