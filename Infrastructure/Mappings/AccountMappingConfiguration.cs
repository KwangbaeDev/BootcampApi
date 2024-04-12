using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class AccountMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAccountModel, Account>()
            .Map(x => x.Holder, src => src.Holder)
            .Map(x => x.Number, src => src.Number)
            .Map(x => x.Type, src => (AccountType)src.Type)
            .Map(x => x.CurrencyId, src => src.CurrencyId)
            .Map(x => x.CustomerId, src => src.CustomerId);

        config.NewConfig<Account, AccountDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Holder, src => src.Holder)
            .Map(x => x.Number, src => src.Number)
            .Map(x => x.Type, src => (AccountStatus)src.Type)
            .Map(x => x.Balance, src => src.Balance)
            .Map(x => x.Status, src => (AccountStatus)src.Status)
            .Map(x => x.IsDeleted, src => (IsDeleteStatus)src.IsDeleted)
            .Map(x => x.Currency, src => src.Currency)
            .Map(x => x.Customer, src => src.Customer);
    }
}
