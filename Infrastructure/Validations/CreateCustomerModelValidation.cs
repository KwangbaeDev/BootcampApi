using Core.Constants;
using Core.Requests;
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
            RuleFor(x => x.CustomerStatus)
                .Must(BeValidCustomerStatus)
                .WithMessage("The CustomerStatus provided is not valid.");


            //RuleFor(x => x.BankId
            //    .NotNull()
            //    .WithMessage("Bank is required.");

            //RuleFor(x => x.BankId)
            //    .Must(BeValidBank)
            //    .WithMessage("Bank not found.");
        }

        private bool BeValidCustomerStatus(int arg)
        {
            return Enum.IsDefined(typeof(CustomerStatus), arg);
        }

        //private bool BeValidBank(int bankId)
        //{
        //    return bankId
        //}


    }
}
