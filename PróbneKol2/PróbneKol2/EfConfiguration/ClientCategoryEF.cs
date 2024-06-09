using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PróbneKol2.Models;

namespace PróbneKol2.EfConfiguration;

public class ClientCategoryEF : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder.ToTable("ClientCategory");

        builder.HasKey(c => c.IdClientCategory);
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.DiscountPerc);
    }
}