using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.DepositModels;
using Core.Requests.ExtractionModels;
using Mapster;

namespace Infrastructure.Mappings;

public class ExtractionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        //config.NewConfig<CreateExtracionModel, Extraction>()



        //Del Creation object hacia la entidad
        config.NewConfig<CreateExtractionModel, Movement>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
            .Map(dest => dest.MovementType, src => MovementType.Extraction)
            .Map(dest => dest.AccountId, src => src.AccountId);



        //Entidad hacia el DTO
        config.NewConfig<Extraction, ExtractionDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Movement, src => src.Movement.Adapt<MovementDTO>());
    }
}
