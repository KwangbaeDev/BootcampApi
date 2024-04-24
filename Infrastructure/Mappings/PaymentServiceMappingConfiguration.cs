using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.PaymentServiceModels;
using Mapster;

namespace Infrastructure.Mappings;

public class PaymentServiceMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreatePaymentServiceModel, PaymentService>()
            //.Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Concept, src => src.Concept)
            .Map(dest => dest.AccountId, src => src.AccountId);



        //Del Creation object hacia la entidad
        //config.NewConfig<CreatePaymentServiceModel, Movement>()
        //    //.Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
        //    .Map(dest => dest.Amount, src => src.Amount)
        //    .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
        //    .Map(dest => dest.MovementType, src => MovementType.PaymentService)
        //    .Map(dest => dest.AccountId, src => src.AccountId);


        //Entidad hacia el DTO
        config.NewConfig<PaymentService, PaymentServiceDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DocumentNumber, src => src.Account.Customer.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Concept, src => src.Concept)
            .Map(dest => dest.PaymentServiceDateTime, src => DateTime.Now)
            .Map(dest => dest.Account, src => src.Account);
    }
}
