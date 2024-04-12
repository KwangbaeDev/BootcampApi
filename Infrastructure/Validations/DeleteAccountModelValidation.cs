using Core.Constants;
using Core.Requests;
using FluentValidation;

namespace Infrastructure.Validations;

public class DeleteAccountModelValidation : AbstractValidator<DeleteAccountModel>
{
    public DeleteAccountModelValidation()
    {
        RuleFor(x => x.IsDeleted)
            .Must(BeValidIsDelete)
            .WithMessage("The IsDelete provided is not valid.");
    }

    private bool BeValidIsDelete(int arg)
    {
        return Enum.IsDefined(typeof(IsDeleteStatus), arg);
    }
}
