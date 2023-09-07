using Common.Application.Validation;
using FluentValidation;

namespace Doctor.Application.RoleAgg.Edit;

public class EditRoleCommandCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}