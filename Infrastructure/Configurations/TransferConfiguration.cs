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
            .HasOne(transfer => transfer.OriginAccount)
            .WithMany(soureAccount => soureAccount.Transfers)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        //entity
        //    .HasOne(transfer => transfer.TargetAccount)
        //    .WithMany(targetAccount => targetAccount.Transfers)
        //    .HasForeignKey(transfer => transfer.TargetAccountId)
        //    .IsRequired(false);
        entity
            .HasOne<Account>()
            .WithMany(targetAccount => targetAccount.Transfers)
            .HasForeignKey(transfer => transfer.DestinationAccountId);

    }
}
