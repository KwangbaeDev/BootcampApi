using Core.Requests.DepositModels;
using FluentValidation;

namespace Infrastructure.Validations.DepositValidations;

public class CreateDepositModelValidation : AbstractValidator<CreateDepositModel>
{
    public CreateDepositModelValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("AccountId is required.");

        RuleFor(x => x.BankId)
            .NotEmpty()
            .WithMessage("BankId is required.");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.");
    }
}
