using Core.Constants;
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
            .NotEmpty()
            .WithMessage("Name is required");

            RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithMessage("Lastname is required");

            RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("DocumentNumber is required");

            RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required");

            RuleFor(x => x.BankId)
            .NotEmpty()
            .WithMessage("BankId is required");

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
