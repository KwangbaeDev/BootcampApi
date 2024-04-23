using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> entity)
    {
        entity
            .HasKey(d => d.Id);


        entity
            .HasOne(deposit => deposit.Movement)
            .WithMany(movement => movement.Deposits)
            .HasForeignKey(deposit => deposit.MovementId);
    }
}
