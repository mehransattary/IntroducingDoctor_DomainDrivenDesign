using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Doctor.Application.MedicalServiceAgg.Edit;

public class Edit_MedicalService_Command_Validator : AbstractValidator<Edit_MedicalService_Command>
{
    public Edit_MedicalService_Command_Validator()
    {
        RuleFor(x => x.title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(x => x.shortDescription).NotEmpty().NotNull().WithMessage(ValidationMessages.required("توضیح کوتاه"));

        RuleFor(x => x.ImageFile).JustImageFile();
    }
}
