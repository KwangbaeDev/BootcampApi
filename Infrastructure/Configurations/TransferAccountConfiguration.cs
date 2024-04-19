using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferAccountConfiguration : IEntityTypeConfiguration<TransferAccount>
{
    public void Configure(EntityTypeBuilder<TransferAccount> entity)
    {
        entity
            .HasKey(ta => new { ta.TransferId, ta.AccountId });


        entity
            .HasOne(transferAccount => transferAccount.Transfer)
            .WithMany(transfer => transfer.TransferAccounts)
            .HasForeignKey(transferAccount => transferAccount.TransferId);

        entity
            .HasOne(transferAccount => transferAccount.Account)
            .WithMany(account => account.TransferAccounts)
            .HasForeignKey(transferAccount => transferAccount.AccountId);
    }
}
