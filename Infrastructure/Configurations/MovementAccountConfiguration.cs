using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MovementAccountConfiguration : IEntityTypeConfiguration<MovementAccount>
{
    public void Configure(EntityTypeBuilder<MovementAccount> entity)
    {
        entity
            .HasKey(ma => new { ma.MovementId, ma.AccountId, ma.TransferId });


        entity
            .HasOne(movementAccount => movementAccount.Movement)
            .WithMany(movement => movement.MovementAccounts)
            .HasForeignKey(movementAccount => movementAccount.MovementId);

        entity
            .HasOne(movementAccount => movementAccount.Transfer)
            .WithMany(transfer => transfer.MovementAccounts)
            .HasForeignKey(movementAccout => movementAccout.TransferId);

        entity
            .HasOne(movementAccount => movementAccount.Account)
            .WithMany(account => account.MovementAccounts)
            .HasForeignKey(movementAccout => movementAccout.AccountId);
    }
}
