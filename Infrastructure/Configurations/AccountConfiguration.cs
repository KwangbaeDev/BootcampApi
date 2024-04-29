using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity
            .HasKey(a => a.Id)
            .HasName("Account_pkey");


        entity
            .Property(a => a.Number)
            .HasMaxLength(100);


        entity
            .Property(a => a.Balance)
            .HasPrecision(20, 5);



        entity
            .HasOne(account => account.Currency)
            .WithMany(currency => currency.Accounts)
            .HasForeignKey(account => account.CurrencyId);

        entity
            .HasOne(account => account.Customer)
            .WithMany(customer => customer.Accounts)
            .HasForeignKey(account => account.CustomerId);

        entity
            .HasOne(account => account.SavingAccount)
            .WithOne(savingAccount => savingAccount.Account)
            .HasForeignKey<SavingAccount>(savingAccount => savingAccount.AccountId);

        entity
            .HasOne(account => account.CurrentAccount)
            .WithOne(savingAccount => savingAccount.Account)
            .HasForeignKey<CurrentAccount>(savingAccount => savingAccount.AccountId);

        entity
            .HasMany(account => account.Transfers)
            .WithOne(transfer => transfer.OriginAccount)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        entity
            .HasMany(account => account.PaymentServices)
            .WithOne(paymentService => paymentService.Account)
            .HasForeignKey(paymentService => paymentService.AccountId);

        entity
            .HasMany(account => account.Deposits)
            .WithOne(deposit => deposit.Account)
            .HasForeignKey(deposit => deposit.AccountId);

        entity
            .HasMany(account => account.Extractions)
            .WithOne(extraction => extraction.Account)
            .HasForeignKey(extraction => extraction.AccountId);
    }
}
