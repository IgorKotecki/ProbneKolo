using Microsoft.EntityFrameworkCore;
using PróbneKol2.Models;

namespace PróbneKol2.Repository;

public class ClientRepo :IClientRepo
{
    private readonly Context.AppContext _context;

    public ClientRepo(Context.AppContext context)
    {
        _context = context;
    }

    public async Task<Client?> GetClientWithReservationsAsync(int idClient)
    {
        return await _context.Clients
            .Include(c => c.ClientCategory)
            .Include(c => c.Reservations)
            .ThenInclude(r => r.BoatStandard)
            .Where(c => c.IdClient == idClient)
            .FirstOrDefaultAsync();
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }
}