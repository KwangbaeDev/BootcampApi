﻿using Core.Constants;
using Core.Requests.CustomerModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validations
{
    public class CreateCustomerModelValidation : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerModelValidation()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

            RuleFor(x => x.Lastname)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

            RuleFor(x => x.DocumentNumber)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

            RuleFor(x => x.Phone)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

            RuleFor(x => x.BankId)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Holder is required");

            RuleFor(x => x.CustomerStatus)
                .Must(BeValidCustomerStatus)
                .WithMessage("The CustomerStatus provided is not valid.");


        }

        private bool BeValidCustomerStatus(int arg)
        {
            return Enum.IsDefined(typeof(CustomerStatus), arg);
        }



    }
}
