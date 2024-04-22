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
            .Map(dest => dest.Description, src => src.Description);



        //Del Creation object hacia la entidad
        config.NewConfig<CreatePaymentServiceModel, Movement>()
            //.Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.Now)
            .Map(dest => dest.MovementType, src => MovementType.PaymentService)
            .Map(dest => dest.AccountId, src => src.AccountId);


        //Entidad hacia el DTO
        config.NewConfig<PaymentService, PaymentServiceDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DocumentNumber, src => src.Movement.Account.Customer.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Movement.Amount)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.MovementId, src => src.MovementId)
            .Map(dest => dest.Movement, src => src.Movement.Adapt<MovementDTO>());
    }
}
