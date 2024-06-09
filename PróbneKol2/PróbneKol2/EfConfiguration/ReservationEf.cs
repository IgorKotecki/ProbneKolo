using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PróbneKol2.Models;

namespace PróbneKol2.EfConfiguration;

public class ReservationEf :IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservation");

        builder.HasKey(r => r.IdReservation);
        builder.HasAlternateKey(c => c.Client.IdClient);
        builder.Property(r => r.DateFrom);
        builder.Property(r => r.DateTo);
        builder.Property(r => r.BoatStandard.IdBoatStandard);
        builder.Property(r => r.Capacity);
        builder.Property(r => r.NumOfBoats);
        builder.Property(r => r.Fulfilled);
        builder.Property(r => r.Price);
        builder.Property(r => r.CancelReason).HasMaxLength(200);
    }
}