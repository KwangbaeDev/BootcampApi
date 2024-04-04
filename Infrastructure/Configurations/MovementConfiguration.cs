using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> entity)
    {
        entity.HasKey(e => e.Id).HasName("Movement_pkey");
        entity.Property(e => e.Destination).HasMaxLength(150).IsRequired();
        entity.Property(e => e.Amount).HasPrecision(20, 5);
        entity.Property(e => e.TransferredDateTime).HasColumnType("timestamp without time zone");


        entity
            .HasOne(movement => movement.Account)
            .WithMany(account => account.Movements)
            .HasForeignKey(movement => movement.AccountId);
    }
}
