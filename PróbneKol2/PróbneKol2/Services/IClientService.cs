using PróbneKol2.Models;

namespace PróbneKol2.Services;

public interface IClientService
{
    Task<Client> GetClientWithReservationsAsync(int idClient);
    Task AddReservationAsync(Reservation reservation);
}