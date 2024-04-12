﻿using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class CurrencyMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCurrencyModel, Currency>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.BuyValue, src => src.BuyValue)
            .Map(x => x.SellValue, src => src.SellValue);


        config.NewConfig<Currency, CurrencyDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.BuyValue, src => src.BuyValue)
            .Map(x => x.SellValue, src => src.SellValue);
    }
}