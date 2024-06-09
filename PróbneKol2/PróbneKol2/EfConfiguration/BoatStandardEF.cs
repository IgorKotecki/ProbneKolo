using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PróbneKol2.Models;

namespace PróbneKol2.EfConfiguration;

public class BoatStandardEF : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder.ToTable("BoatStandard");

        builder.HasKey(b => b.IdBoatStandard);

        builder.Property(b => b.Name).HasMaxLength(100);
        builder.Property(b => b.Level);
    }
}