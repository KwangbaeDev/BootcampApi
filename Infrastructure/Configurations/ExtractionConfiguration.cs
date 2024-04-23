using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExtractionConfiguration : IEntityTypeConfiguration<Extraction>
{
    public void Configure(EntityTypeBuilder<Extraction> entity)
    {
        entity
            .HasKey(e => e.Id);

        entity
            .Property(e => e.Amount)
            //.HasPrecision(20, 5)
            .IsRequired();

        entity
            .Property(e => e.ExtractionDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        entity
            .Property(e => e.Description)
            .IsRequired();

        




        //entity
        //    .HasOne(extraction => extraction.Movement)
        //    .WithMany(movement => movement.Extractions)
        //    .HasForeignKey(extraction => extraction.MovementId);
    }
}
