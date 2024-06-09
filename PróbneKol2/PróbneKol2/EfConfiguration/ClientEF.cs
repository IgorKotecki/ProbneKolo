using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PróbneKol2.Models;

namespace PróbneKol2.EfConfiguration;

public class ClientEF :IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(c => c.IdClient);
        builder.HasAlternateKey(c=>c.ClientCategory.IdClientCategory);
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.Lastname).HasMaxLength(100);
        builder.Property(c => c.Birthday);
        builder.Property(c => c.Pesel).HasMaxLength(100);
        builder.Property(c => c.Email).HasMaxLength(100);
    }
}