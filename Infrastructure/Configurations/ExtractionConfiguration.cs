using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExtractionConfiguration : IEntityTypeConfiguration<Extraction>
{
    public void Configure(EntityTypeBuilder<Extraction> entity)
    {
        entity
            .HasKey(d => d.Id);


        entity
            .HasOne(extraction => extraction.Movement)
            .WithMany(movement => movement.Extractions)
            .HasForeignKey(extraction => extraction.MovementId);
    }
}
