using Core.Requests.ApplicationFormModels;
using FluentValidation;
using Mapster;

namespace Infrastructure.Validations.ApplicationFormValidations;

public class CreateApplicationFormModelValidation : AbstractValidator<CreateApplicationFormModel>
{
    public CreateApplicationFormModelValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithMessage("LastName is required");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("DocumentNumber is required");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required");

        RuleFor(x => x.CurrencyId)
            .NotEmpty()
            .WithMessage("CorrencyId is required");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
    }
}
