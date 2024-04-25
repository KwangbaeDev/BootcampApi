using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.CreditCardModels;
using Mapster;

namespace Infrastructure.Mappings;

public class CreditCardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCreditCardModel, CreditCard>()
            .Map(x => x.Designation, src => src.Designation)
            .Map(x => x.IssueDate, src => src.IssueDate)
            .Map(x => x.ExpirationDate, src => src.ExpirationDate)
            .Map(x => x.CardNumber, src => src.CardNumber)
            .Map(x => x.CVV, src => src.CVV)
            .Map(x => x.CreditCardStatus, src => (CreditCardStatus)src.CreditCardStatus)
            .Map(x => x.CreditLimit, src => src.CreditLimit)
            .Map(x => x.AvailableCredit, src => src.AvailableCredit)
            .Map(x => x.CurrentDebt, src => src.CurrentDebt)
            .Map(x => x.InterestRate, src => src.InterestRate)
            .Map(x => x.CustomerId, src => src.CustomerId)
            .Map(x => x.CurrencyId, src => src.CurrencyId);



        config.NewConfig<CreditCard, CreditCardDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Designation, src => src.Designation)
            .Map(x => x.IssueDate, src => src.IssueDate)
            .Map(x => x.ExpirationDate, src => src.ExpirationDate)
            .Map(x => x.CardNumber, src => src.CardNumber)
            .Map(x => x.CVV, src => src.CVV)
            .Map(x => x.CreditCardStatus, src => (CreditCardStatus)src.CreditCardStatus)
            .Map(x => x.CreditLimit, src => src.CreditLimit)
            .Map(x => x.AvailableCredit, src => src.AvailableCredit)
            .Map(x => x.CurrentDebt, src => src.CurrentDebt)
            .Map(x => x.InterestRate, src => src.InterestRate)
            .Map(x => x.RestrictedCreditCard, src => $"xxxx-xxxx-xxxx-{src.CardNumber.Substring(src.CardNumber.Length - 4)}")
            .Map(x => x.Customer, src => src.Customer)
            .Map(x => x.Currency, src => src.Currency);
    }
}
