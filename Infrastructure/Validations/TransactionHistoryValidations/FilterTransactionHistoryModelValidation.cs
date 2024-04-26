using Core.Requests.TransactionHistoryModels;
using FluentValidation;

namespace Infrastructure.Validations.TransactionHistoryValidations;

public class FilterTransactionHistoryModelValidation : AbstractValidator<FilterTransactionHistoryModel>
{
    public FilterTransactionHistoryModelValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("AccountId is required.");

        RuleFor(x => x.Month)
            .NotEmpty().When(x => x.Year != null)
            .WithMessage("Month is required if I already enter the year.");

        RuleFor(x => x.Year)
            .NotEmpty().When(x => x.Month != null)
            .WithMessage("Year is required if I already enter the month.");

        RuleFor(x => x.DateFrom)
            .NotEmpty().When(x => x.DateTo != null)
            .WithMessage("DateFrom is required if I already enter the DateTo.");

        RuleFor(x => x.DateTo)
            .NotEmpty().When(x => x.DateFrom != null)
            .WithMessage("DateTo is required if I already enter the DateFrom.");
    }
}
