using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.DepositModels;
using Mapster;

namespace Infrastructure.Mappings;

public class DepositMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateDepositModel, Deposit>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.BankId, src => src.BankId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.DepositDateTime, src => DateTime.Now);



        //Entidad hacia el DTO
        config.NewConfig<Deposit, DepositDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.DepositDateTime, src => src.DepositDateTime)
            .Map(dest => dest.Account, src => src.Account)
            .Map(dest => dest.Bank, src => src.Bank);







    }
}
