using Core.Entities;
using Core.Models;
using Mapster;

namespace Infrastructure.Mappings;

public class PromotionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Entidad hacia el DTO
        config.NewConfig<Promotion, PromotionDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.DurationTime, src => src.DurationTime)
            .Map(x => x.PercentageOff, src => src.PercentageOff)
            .Map(x => x.CompanyBusiness, src => src.CompanyBusinesses);
    }
}
