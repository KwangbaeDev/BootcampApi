using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity
            .HasKey(t => t.Id);

        entity
            .Property(t => t.DestinationBank)
            .IsRequired();

        entity
            .Property(t => t.AccountNumber)
            .IsRequired();

        entity
            .Property(t => t.DocumentNumber)
            .IsRequired();



        entity
            .HasOne(transfer => transfer.SourceAccount)
            .WithMany(soureAccount => soureAccount.Transfers)
            .HasForeignKey(transfer => transfer.SourceAccountId)
            .IsRequired(true);

        //entity
        //    .HasOne(transfer => transfer.TargetAccount)
        //    .WithMany(targetAccount => targetAccount.Transfers)
        //    .HasForeignKey(transfer => transfer.TargetAccountId)
        //    .IsRequired(false);
        entity
            .HasOne<Account>()
            .WithMany(targetAccount => targetAccount.Transfers)
            .HasForeignKey(transfer => transfer.TargetAccountId)
            .IsRequired(false);

        entity
            .HasOne(transfer => transfer.Currency)
            .WithMany(currency => currency.Transfers)
            .HasForeignKey(transfer => transfer.CurrencyId);

        entity
            .HasMany(transfer => transfer.MovementAccounts)
            .WithOne(movementAccout => movementAccout.Transfer)
            .HasForeignKey(movementAccount => movementAccount.TransferId);

    }
}
