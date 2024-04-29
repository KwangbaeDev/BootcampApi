using Core.Entities;
using Core.Models;
using Core.Requests.CurrencyModels;
using Mapster;

namespace Infrastructure.Mappings;

public class CurrencyMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateCurrencyModel, Currency>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.BuyValue, src => src.BuyValue)
            .Map(x => x.SellValue, src => src.SellValue);



        //Entidad hacia el DTO
        config.NewConfig<Currency, CurrencyDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.BuyValue, src => src.BuyValue)
            .Map(x => x.SellValue, src => src.SellValue);
    }
}
