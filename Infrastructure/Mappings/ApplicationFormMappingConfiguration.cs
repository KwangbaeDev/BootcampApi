using Core.Constants;
using Core.Entities;
using Core.Requests;
using Core.Models;
using Core.Requests.ApplicationFormModels;
using Infrastructure.Migrations;
using Mapster;
using Core.Requests.ProductModels;

namespace Infrastructure.Mappings;

public class ApplicationFormMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateApplicationFormModel, ApplicationForm>()
            .Map(dest => dest.Descripcion, src => src.Descripcion)
            .Map(dest => dest.ApplicationDate, src => src.ApplicationDate)
            .Map(dest => dest.RequestStatus, src => src.RequestStatus)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId);
        //.Map(dest => dest.Product, src => src.Product);


        config.NewConfig<CreateProductModel, Product>()
            .Map(dest => dest.ProductType, src => src.ProductType);




        //Entidad hacia el DTO
        config.NewConfig<ApplicationForm, ApplicationFormDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Customer.Name) // Ejemplo de mapeo de una propiedad de navegación
            .Map(dest => dest.Lastname, src => src.Customer.Lastname) // Otro ejemplo de mapeo de una propiedad de navegación
            .Map(dest => dest.DocumentNumber, src => src.Customer.DocumentNumber) // Otro ejemplo de mapeo de una propiedad de navegación
            .Map(dest => dest.Address, src => src.Customer.Address)
            .Map(dest => dest.Mail, src => src.Customer.Mail)
            .Map(dest => dest.Phone, src => src.Customer.Phone)
            .Map(dest => dest.Descripcion, src => src.Descripcion)
            .Map(dest => dest.ApplicationDate, src => src.ApplicationDate)
            .Map(dest => dest.ApprovalDate, src => src.ApprovalDate)
            .Map(dest => dest.RejectionDate, src => src.RejectionDate)
            .Map(dest => dest.RequestStatus, src => src.RequestStatus)
            .Map(dest => dest.Customer, src => src.Customer)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Product, src => src.Product);


        config.NewConfig<Product, ProductDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ProductType, src => src.ProductType.ToString());
    }
}
