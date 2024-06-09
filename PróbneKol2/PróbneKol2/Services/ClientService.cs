using PróbneKol2.Models;
using PróbneKol2.Repository;

namespace PróbneKol2.Services;

public class ClientService :IClientService
{
    private readonly IClientRepo _clientRepository;

    public ClientService(IClientRepo clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> GetClientWithReservationsAsync(int idClient)
    {
        return await _clientRepository.GetClientWithReservationsAsync(idClient);
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        await _clientRepository.AddReservationAsync(reservation);
    }
}