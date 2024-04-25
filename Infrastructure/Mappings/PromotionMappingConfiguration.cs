using Core.Entities;
using Core.Models;
using Core.Requests.PromotionModels;
using Mapster;

namespace Infrastructure.Mappings;

public class PromotionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreatePromotionModel, Promotion>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Start, src => src.Start)
            .Map(x => x.End, src => src.End)
            .Map(x => x.Discount, src => src.Discount);


        //Entidad hacia el DTO
        config.NewConfig<Promotion, PromotionDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Start, src => src.Start)
            .Map(x => x.End, src => src.Start)
            .Map(x => x.Discount, src => src.Discount)
            .AfterMapping((src, x) =>
            {
                x.Enterprises = src.PromotionsEnterprises
                .Select(pe => pe.Enterprise.Adapt<EnterpriseDTO>())
                .ToList();
            });
    }
}
