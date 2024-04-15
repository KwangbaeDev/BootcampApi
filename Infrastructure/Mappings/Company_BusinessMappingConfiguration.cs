using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class Company_BusinessMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateCompany_BusinessModel, Company_Business>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.Email, src => src.Email);

        //Entidad hacia el DTO
        config.NewConfig<Company_Business, Company_BusinessDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.Email, src => src.Email);
    }
}
