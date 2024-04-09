using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Infrastructure.Mappings;

public class CustomerMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerModel, Customer>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Lastname, src => src.Lastname)
            .Map(x => x.DocumentNumber, src => src.DocumentNumber)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Mail, src => src.Mail)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.CustomerStatus, src => (CustomerStatus)src.CustomerStatus)
            .Map(x => x.Birth, src => src.Birth)
            .Map(x => x.BankId, src => src.BankId);

        config.NewConfig<Customer, CustomerDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Lastname, src => src.Lastname)
            .Map(x => x.DocumentNumber, src => src.DocumentNumber)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Mail, src => src.Mail)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.CustomerStatus, src => (CustomerStatus)src.CustomerStatus)
            .Map(x => x.Birth, src => src.Birth)
            .Map(x => x.Bank, src => src.Bank);
    }
}
