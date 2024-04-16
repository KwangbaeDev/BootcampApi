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
        //Del Creation object hacia la entidad
        config.NewConfig<CreateAccountModel, Account>()
            .Map(x => x.Holder, src => src.Holder)
            .Map(x => x.Number, src => src.Number)
            .Map(x => x.Type, src => (AccountType)src.Type)
            .Map(x => x.CurrencyId, src => src.CurrencyId)
            .Map(x => x.CustomerId, src => src.CustomerId);


        config.NewConfig<CreateSavingAccountModel, SavingAccount>()
            .Map(dest => dest.SavingType, src => src.SavingType);


        config.NewConfig<CreateCurrentAccountModel, CurrentAccount>()
            .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
            .Map(dest => dest.MonthAverage, src => src.MonthAverage)
            .Map(dest => dest.Interest, src => src.Interest);

        //Entidad hacia el DTO
        config.NewConfig<Account, AccountDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Holder, src => src.Holder)
            .Map(x => x.Number, src => src.Number)
            .Map(x => x.Type, src => (AccountStatus)src.Type)
            .Map(x => x.Balance, src => src.Balance)
            .Map(x => x.Status, src => (AccountStatus)src.Status)
            //.Map(x => x.IsDeleted, src => (IsDeleteStatus)src.IsDeleted)
            .Map(x => x.Currency, src => src.Currency)
            .Map(x => x.Customer, src => src.Customer)
            .Map(dest => dest.SavingAccount, src =>
                src.SavingAccount != null
                ? src.SavingAccount
                : null)
            .Map(dest => dest.CurrentAccount, src =>
                src.CurrentAccount != null
                ? src.CurrentAccount
                : null);


        config.NewConfig<SavingAccount, SavingAcountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.SavingType, src => src.SavingType.ToString());


        config.NewConfig<CurrentAccount, CurrentAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
            .Map(dest => dest.MonthAverage, src => src.MonthAverage)
            .Map(dest => dest.Interest, src => src.Interest);
    }
}
