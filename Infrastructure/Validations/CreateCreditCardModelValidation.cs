using Core.Constants;
using Core.Requests.CreditCardModels;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateCreditCardModelValidation : AbstractValidator<CreateCreditCardModel>
{
    public CreateCreditCardModelValidation()
    {
        RuleFor(x => x.CreditLimit)
            .NotNull().WithMessage("CreditLimit cannot be null")
            .GreaterThan(0).WithMessage("CreditLimit must be greater than zero");

        RuleFor(x => x.AvailableCredit)
            .NotNull().WithMessage("AvaibleCredit cannot be null")
            .GreaterThan(5000000).WithMessage("In terest must be greater than five hundred thousand");

        RuleFor(x => x.InterestRate)
            .NotNull().WithMessage("InterestRate cannot be null")
            .GreaterThan(0).WithMessage("InterestRate must be greater than zero");

        RuleFor(x => x.CreditCardStatus)
            .Must(BeValidCreditCardStatus).WithMessage("The CreditCardStatus provided is not valid");
    }

    public bool BeValidCreditCardStatus(int arg)
    {
        return Enum.IsDefined(typeof(CreditCardStatus), arg);
    }
}
