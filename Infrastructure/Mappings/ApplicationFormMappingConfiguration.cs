﻿using Core.Constants;
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
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.ApplicationDate, src => DateTime.Now)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.ProductId, src => src.ProductId);



        //Entidad hacia el DTO
        config.NewConfig<ApplicationForm, ApplicationFormDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Customer.Name) // Mapeo de una propiedad de navegación
            .Map(dest => dest.Lastname, src => src.Customer.Lastname) // Mapeo de una propiedad de navegación
            .Map(dest => dest.DocumentNumber, src => src.Customer.DocumentNumber) //Mapeo de una propiedad de navegación
            .Map(dest => dest.Address, src => src.Customer.Address)//Mapeo de una propiedad de navegación
            .Map(dest => dest.Mail, src => src.Customer.Mail)//Mapeo de una propiedad de navegación
            .Map(dest => dest.Phone, src => src.Customer.Phone)//Mapeo de una propiedad de navegación
            .Map(dest => dest.Desciption, src => src.Description)
            .Map(dest => dest.ApplicationDate, src => src.ApplicationDate)
            .Map(dest => dest.ApprovalDate, src => src.ApprovalDate)
            .Map(dest => dest.RejectionDate, src => src.RejectionDate)
            .Map(dest => dest.RequestStatus, src => src.RequestStatus)
            .Map(dest => dest.Customer, src => src.Customer)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Product, src => src.Product);
    }
}
