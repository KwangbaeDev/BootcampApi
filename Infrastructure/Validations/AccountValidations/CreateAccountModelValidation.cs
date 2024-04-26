using Core.Constants;
using Core.Entities;
using Core.Requests.AccountModels;
using FluentValidation;
using System.Linq;

namespace Infrastructure.Validations.AccountValidation;

public class CreateAccountModelValidation : AbstractValidator<CreateAccountModel>
{
    public CreateAccountModelValidation()
    {
        RuleFor(x => x.Holder)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

        RuleFor(x => x.Number)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Number is required");

        List<AccountType> validValues = new List<AccountType>() { AccountType.Saving, AccountType.Current };
        RuleFor(x => x.Type)
            .Must(x => validValues.Contains(x)).WithMessage("Type should only have the values ​​'0 --> Saving' | '1 --> Current'.");

        RuleFor(x => x.CurrencyId)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("CurrencyId is required");

        RuleFor(x => x.CustomerId)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("CustomerId is required");

        List<SavingType> validValuesSavingAccount = new List<SavingType>() { SavingType.Permanent, SavingType.Insight };
        RuleFor(x => x.CreateSavingAccount!.SavingType)
            .NotEmpty().When(x => x.Type == AccountType.Saving)
            .WithMessage("SavingType is required if the account type is Saving.")
            .Must(x => validValuesSavingAccount.Contains(x)).When(x => x.Type == AccountType.Saving)
            .WithMessage("SavingType Should only have the values ​​'0 --> Permanent' | '1 --> Insight'.");

        RuleFor(x => x.CreateCurrentAccount!.OperationalLimit)
            .NotEmpty().When(x => x.Type == AccountType.Current)
            .WithMessage("OperationalLimit is required if the account type is Current.");

        RuleFor(x => x.CreateCurrentAccount!.MonthAverage)
            .NotEmpty().When(x => x.Type == AccountType.Current)
            .WithMessage("MonthAverage is required if the account type is Current.");

        RuleFor(x => x.CreateCurrentAccount!.Interest)
            .NotEmpty().When(x => x.Type == AccountType.Current)
            .WithMessage("Interest is required if the account type is Current.");
    }
}
