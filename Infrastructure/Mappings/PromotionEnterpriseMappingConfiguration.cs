using Core.Entities;
using Core.Models;
using Mapster;

namespace Infrastructure.Mappings;

public class PromotionEnterpriseMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Entidad hacia el DTO
        config.NewConfig<PromotionEnterprise, PromotionEnterpriseDTO>()
            .Map(x => x.Promotion, src => src.Promotion)
            .Map(x => x.Enterprise, src => src.Enterprise);
    }
}
