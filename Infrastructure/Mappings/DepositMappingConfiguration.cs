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
        //config.NewConfig<CreateDepositModel, Deposit>()
        //    .Map(dest => dest.Description, src => src.Description);




        //Del Creation object hacia la entidad
        config.NewConfig<CreateDepositModel, Movement>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
            .Map(dest => dest.MovementType, src => MovementType.Deposit)
            .Map(dest => dest.AccountId, src => src.AccountId);




        //Entidad hacia el DTO
        config.NewConfig<Deposit, DepositDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Movement, src => src.Movement.Adapt<MovementDTO>());
    }
}
