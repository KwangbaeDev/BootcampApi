using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity
            .HasKey(af => af.Id);

        entity
            .Property(af => af.DestinationBank)
            .IsRequired();

        entity
            .Property(af => af.AccountNumber)
            .IsRequired();

        entity
            .Property(af => af.DocumentNumber)
            .IsRequired();

        entity
            .Property(af => af.Amount)
            .IsRequired();

        entity
            .Property(af => af.DateOfOperation)
            .IsRequired();


        entity
            .HasOne(transfer => transfer.SourceAccount)
            .WithMany(soureAccount => soureAccount.Transfers)
            .HasForeignKey(transfer => transfer.SourceAccountId);

        entity
            .HasOne(transfer => transfer.TargetAccount)
            .WithMany(targetAccount => targetAccount.Transfers)
            .HasForeignKey(transfer => transfer.TargetAccountId);

        entity
            .HasOne(transfer => transfer.Currency)
            .WithMany(currency => currency.Transfers)
            .HasForeignKey(transfer => transfer.CurrencyId);

        entity
            .HasMany(transfer => transfer.TransferAccounts)
            .WithOne(transferAccount => transferAccount.Transfer)
            .HasForeignKey(transferAccount => transferAccount.TransferId);

    }
}
