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
            .WithMessage("Amount is required.");

        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("AccountId is required.");

        RuleFor(x => x.ServiceId)
            .NotEmpty()
            .WithMessage("ServiceId is required.");
    }
}
