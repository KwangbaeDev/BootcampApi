﻿using Core.Constants;
using Core.Requests.TransferModels;
using FluentValidation;

namespace Infrastructure.Validations.TransferValidations;

public class CreateTransferModelValidation : AbstractValidator<CreateTransferModel>
{
    public CreateTransferModelValidation()
    {
        RuleFor(x => x.OriginAccountId)
            .NotEmpty()
            .WithMessage("OriginAccountId is required");

        List<TransferType> validValues = new List<TransferType>() { TransferType.SameBank, TransferType.AnotherBank };
        RuleFor(x => x.TransferType)
            .Must(x => validValues.Contains(x)).WithMessage("It should only have the values ​​'0 --> SameBank' | '1 --> AnotherBank'.");

        RuleFor(x => x.DenstinationBankId)
            .NotEmpty().When(x => x.TransferType == TransferType.AnotherBank)
            .WithMessage("DenstinationBankId is required");

        RuleFor(x => x.AccountNumber)
            .NotEmpty()
            .WithMessage("AccountNumber is required");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("DocumentNumber is required");

        RuleFor(x => x.CurrencyId)
            .NotEmpty().When(x => x.TransferType == TransferType.AnotherBank)
            .WithMessage("CurrencyId is required");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.")
            .GreaterThan(-1)
            .WithMessage("The transfer amount cannot be negative.")
            .PrecisionScale(8, 0, false)
            .WithMessage("The amount cannot have '.'");
    }
}
