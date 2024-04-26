using Core.Requests.ExtractionModels;
using FluentValidation;

namespace Infrastructure.Validations.ExtractionValidations;

public class CreateExtractionValidation : AbstractValidator<CreateExtractionModel>
{
    public CreateExtractionValidation()
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
