using Microsoft.EntityFrameworkCore;
using PróbneKol2.Models;

namespace PróbneKol2.Context;

public class AppContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    public DbSet<SailboatReservation> SailboatReservations { get; set; }

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.ClientCategory)
            .WithMany()
            .HasForeignKey(c => c.IdClientCategory);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Client)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.IdClient);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.BoatStandard)
            .WithMany()
            .HasForeignKey(r => r.IdBoatStandard);

        modelBuilder.Entity<Sailboat>()
            .HasOne(s => s.BoatStandard)
            .WithMany()
            .HasForeignKey(s => s.IdBoatStandard);

        modelBuilder.Entity<SailboatReservation>()
            .HasKey(sr => new { sr.IdSailboat, sr.IdReservation });

        modelBuilder.Entity<SailboatReservation>()
            .HasOne(sr => sr.Sailboat)
            .WithMany(s => s.SailboatReservations)
            .HasForeignKey(sr => sr.IdSailboat);

        modelBuilder.Entity<SailboatReservation>()
            .HasOne(sr => sr.Reservation)
            .WithMany(r => r.SailboatReservations)
            .HasForeignKey(sr => sr.IdReservation);
    }
}