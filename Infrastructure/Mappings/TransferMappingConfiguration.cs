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
            //.Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            ////.Map(dest => dest.TrasferType, src => src.TransferType)
            ////.Map(dest => dest.DestinationBankId, src => src.DestinationBankId)
            ////.Map(dest => dest.AccountNumber, src => src.AccountNumber)
            ////.Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            //.Map(dest => dest.DestinationAccountId, src => src.DenstinationBankId)
            //.Map(dest => dest.MovementId, src => src.CurrencyId);
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId);
        //.Map(dest => dest.DestinationAccountId, src => src.DenstinationBankId)
        //.Map(dest => dest.MovementId, src => src.CurrencyId);

        config.NewConfig<CreateTransferModel, Movement>()
            .Map(dest => dest.Destination, src => src.AccountNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
            .Map(dest => dest.TransferStatus, src => TransferStatus.Done)
            .Map(dest => dest.MovementType, src => MovementType.SentTransfer)
            .Map(dest => dest.AccountId, src => src.OriginAccountId);

        //Entidad hacia el DTO
        config.NewConfig<Transfer, TransferDTO>()
            //.Map(dest => dest.Id, src => src.Id)
            //.Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            ////.Map(dest => dest.TransferType, src => src.TransferType)
            //.Map(dest => dest.DestinationAccountId, src => src.DestinationAccountId)
            //.Map(dest => dest.AccountNumber, src => src.AccountNumber)
            //.Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            //.Map(dest => dest.CurrencyId, src => src.CurrencyId)
            //.Map(dest => dest.Amount, src => src.Amount)
            //.Map(dest => dest.Id, src => src.Id)
            //.Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.MovementId, src => src.MovementId)
            .Map(dest => dest.DestinationAccountId, src => src.DestinationAccountId)
            //Al mostrar el DTO se pasa cuenta de destino al origen ya que el origen ya lo tenemos en el movimiento
            .Map(dest => dest.DestiationAccount, src => src.OriginAccount.Adapt<AccountDTO>()) 
            .Map(dest => dest.Movement, src => src.Movement.Adapt<MovementDTO>());


    }
}
