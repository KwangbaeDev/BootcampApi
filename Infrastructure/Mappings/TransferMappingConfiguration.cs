using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.TransferModels;
using Mapster;

namespace Infrastructure.Mappings;

public class TransferMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateTransferModel, Transfer>()
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.DestinationBankId, src => src.DenstinationBankId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
            .Map(dest => dest.Concept, src => src.Concept);



        //Entidad hacia el DTO
        config.NewConfig<Transfer, TransferDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransferType, src => 
                src.OriginAccount.Customer.BankId == src.DestinationBankId 
                ? TransferType.SameBank 
                : TransferType.AnotherBank)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => src.TransferredDateTime)
            .Map(dest => dest.Concept, src => src.Concept)
            .Map(dest => dest.OriginAccount, src => src.OriginAccount)
            .Map(dest => dest.Bank, src => src.Bank)
            .Map(dest => dest.Currency, src => src.Currency);
    }
}
