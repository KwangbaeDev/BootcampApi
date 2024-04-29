using Core.Requests.PaymentServiceModels;
using Core.Requests.PromotionModels;
using FluentValidation;

namespace Infrastructure.Validations.PaymentServiceValidations;

public class CreatePaymentServiceValidation : AbstractValidator<CreatePaymentServiceModel>
{
    public CreatePaymentServiceValidation()
    {
        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("DocumentNumber is required.");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.")
            .GreaterThan(-1)
            .WithMessage("The payment amount cannot be negative.")
            .PrecisionScale(8, 0, false)
            .WithMessage("The amount cannot have '.'");

        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("AccountId is required.");

        RuleFor(x => x.ServiceId)
            .NotEmpty()
            .WithMessage("ServiceId is required.");
    }
}
