using System;
using System.Collections.Generic;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class BootcampContext : DbContext
{
    public BootcampContext()
    {
    }

    public BootcampContext(DbContextOptions<BootcampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<SavingAccount> SavingAccounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Enterprise> Enterprises { get; set; }

    public virtual DbSet<PromotionEnterprise> PromotionEnterprises { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ApplicationForm> ApplicationForms { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<PaymentService> PaymentServices { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Extraction> Extractions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());

        modelBuilder.ApplyConfiguration(new BankConfiguration());

        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());

        modelBuilder.ApplyConfiguration(new CurrentAccountConfiguration());

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        modelBuilder.ApplyConfiguration(new SavingAccountConfiguration());

        modelBuilder.ApplyConfiguration(new CreditCardConfiguration());

        modelBuilder.ApplyConfiguration(new EnterpriseConfiguration());

        modelBuilder.ApplyConfiguration(new PromotionConfiguration());

        modelBuilder.ApplyConfiguration(new PromotionEnterpriseConfiguration());

        modelBuilder.ApplyConfiguration(new CreditConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        modelBuilder.ApplyConfiguration(new ApplicationFormConfiguration());

        modelBuilder.ApplyConfiguration(new TransferConfiguration());

        modelBuilder.ApplyConfiguration(new PaymentServiceConfiguration());

        modelBuilder.ApplyConfiguration(new DepositConfiguration());

        modelBuilder.ApplyConfiguration(new ExtractionConfiguration());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
