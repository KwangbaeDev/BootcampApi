﻿using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddServices();
        services.AddMapping();
        services.AddValidation();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Bootcamp");

        services.AddDbContext<BootcampContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
        services.AddScoped<IPaymentServiceRepository, PaymentServiceRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICreditCardService, CreditCardService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IEnterpriseService, EnterpriseService>();
        services.AddScoped<IPromotionService, PromotionService>();
        services.AddScoped<IApplicationFormService, ApplicationFormService>();
        services.AddScoped<ITransferService, TransferService>();
        services.AddScoped<IPaymentServiceService, PaymentServiceService>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
