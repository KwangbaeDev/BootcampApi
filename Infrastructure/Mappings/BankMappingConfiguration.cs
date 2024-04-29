using Core.Entities;
using Core.Models;
using Core.Requests.BankModels;
using Mapster;

namespace Infrastructure.Mappings;

public class BankMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateBankModel, Bank>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone);



        //Entidad hacia el DTO
        config.NewConfig<Bank, BankDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone);
    }
}