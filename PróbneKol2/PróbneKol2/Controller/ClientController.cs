using Microsoft.AspNetCore.Mvc;
using PróbneKol2.DTO_s;
using PróbneKol2.Models;
using PróbneKol2.Services;
using AppContext = PróbneKol2.Context.AppContext;

namespace PróbneKol2.Controller;

[ApiController]
[Route("/api/[controller]")]
public class ClientController :ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet("{idClient}/reservations")]
    public async Task<IActionResult> GetClientReservations(int idClient)
    {
        var client = await _clientService.GetClientWithReservationsAsync(idClient);

        if (client == null)
        {
            return NotFound();
        }

        var result = new
        {
            client.IdClient,
            client.Name,
            client.Lastname,
            client.Birthday,
            client.Pesel,
            client.Email,
            client.ClientCategory,
            Reservations = client.Reservations
                .OrderByDescending(r => r.DateTo)
                .Select(r => new
                {
                    r.IdReservation,
                    r.DateFrom,
                    r.DateTo,
                    r.BoatStandard,
                    r.Capacity,
                    r.NumOfBoats,
                    r.Fulfilled,
                    r.Price,
                    r.CancelReason
                })
        };

        return Ok(result);
    }
    
    [HttpPost("reservations")]
    public async Task<IActionResult> AddReservation([FromBody] ReservationDTO reservationDto)
    {
        if (reservationDto == null)
        {
            return BadRequest();
        }

        var reservation = new Reservation
        {
            IdClient = reservationDto.IdClient,
            DateFrom = reservationDto.DateFrom,
            DateTo = reservationDto.DateTo,
            IdBoatStandard = reservationDto.IdBoatStandard,
            Capacity = reservationDto.Capacity,
            NumOfBoats = reservationDto.NumOfBoats,
            Fulfilled = reservationDto.Fulfilled,
            Price = reservationDto.Price,
            CancelReason = reservationDto.CancelReason
        };

        await _clientService.AddReservationAsync(reservation);
        return CreatedAtAction(nameof(GetClientReservations), new { idClient = reservation.IdClient }, reservation);
    }
}