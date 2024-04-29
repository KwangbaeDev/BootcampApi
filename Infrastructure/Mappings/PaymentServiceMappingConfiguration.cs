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
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Concept, src => src.Concept)
            .Map(dest => dest.PaymentServiceDateTime, src => DateTime.Now)
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.ServiceId, src => src.ServiceId);



        //Entidad hacia el DTO
        config.NewConfig<PaymentService, PaymentServiceDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DocumentNumber, src => src.Account.Customer.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Concept, src => src.Concept)
            .Map(dest => dest.PaymentServiceDateTime, src => src.PaymentServiceDateTime)
            .Map(dest => dest.Account, src => src.Account)
            .Map(dest => dest.Service, src => src.Service);
    }
}
