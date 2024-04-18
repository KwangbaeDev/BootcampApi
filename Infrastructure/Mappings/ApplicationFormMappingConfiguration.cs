using Core.Constants;
using Core.Entities;
using Core.Requests;
using Core.Models;
using Core.Requests.ApplicationFormModels;
using Infrastructure.Migrations;
using Mapster;

namespace Infrastructure.Mappings;

public class ApplicationFormMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateApplicationFormModel, ApplicationForm>()
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Lastname, src => src.Lastname)
            .Map(x => x.DocumentNumber, src => src.DocumentNumber)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Mail, src => src.Mail)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.Descripcion, src => src.Descripcion)
            .Map(x => x.ApplicationDate, src => src.ApplicationDate)
            .Map(x => x.RequestStatus, src => (RequestStatus)src.RequestStatus)
            .Map(x => x.CustomerId, src => src.CustomerId)
            .Map(x => x.CurrencyId, src => src.CurrencyId)
            .Map(x => x.Product, src => src.Product);


        //Entidad hacia el DTO
        config.NewConfig<ApplicationForm, ApplicationFormDTO>()
            .Map(x => x.Id, src => src.Id)
            .Map(x => x.Name, src => src.Name)
            .Map(x => x.Lastname, src => src.Lastname)
            .Map(x => x.DocumentNumber, src => src.DocumentNumber)
            .Map(x => x.Address, src => src.Address)
            .Map(x => x.Mail, src => src.Mail)
            .Map(x => x.Phone, src => src.Phone)
            .Map(x => x.Descripcion, src => src.Descripcion)
            .Map(x => x.ApplicationDate, src => src.ApplicationDate)
            .Map(x => x.ApprovalDate, src => src.ApprovalDate)
            .Map(x => x.RejectionDate, src => src.RejectionDate)
            .Map(x => x.RequestStatus, src => (RequestStatus)src.RequestStatus)
            .Map(x => x.Customer, src => src.Customer)
            .Map(x => x.Currency, src => src.Currency)
            .Map(x => x.Product, src => src.Product);
    }
}
