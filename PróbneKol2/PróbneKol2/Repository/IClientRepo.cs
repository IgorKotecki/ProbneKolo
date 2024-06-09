using PróbneKol2.Models;

namespace PróbneKol2.Repository;

public class IClientRepo
{
    public Task<Client> GetClientWithReservationsAsync(int idClient)
    {
        throw new NotImplementedException();
    }

    public Task AddReservationAsync(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}