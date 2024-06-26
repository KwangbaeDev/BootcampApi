﻿using Core.Constants;
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
        config.NewConfig<CreateExtractionModel, Extraction>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.BankId, src => src.BankId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.ExtractionDateTime, src => DateTime.Now);



        //Entidad hacia el DTO
        config.NewConfig<Extraction, ExtractionDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.ExtractionDateTime, src => src.ExtractionDateTime)
            .Map(dest => dest.Account, src => src.Account)
            .Map(dest => dest.Bank, src => src.Bank);
    }
}
