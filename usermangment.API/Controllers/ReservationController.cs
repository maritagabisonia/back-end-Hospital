using Microsoft.AspNetCore.Mvc;
using usermangment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace usermangment.API.Controllers
{
    public class ReservationController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class ReservationsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public ReservationsController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
            {
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetReservation(int id)
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }

            [HttpGet("ByUserEmail/{email}")]
            public async Task<IActionResult> GetReservationsByUserEmail(string email)
            {
                var reservations = await _context.Reservations
                                                 .Where(r => r.EmailOfUser == email)
                                                 .ToListAsync();
                return Ok(reservations);
            }

            [HttpGet("ByDoctorEmail/{email}")]
            public async Task<IActionResult> GetReservationsByDoctorEmail(string email)
            {
                var reservations = await _context.Reservations
                                                 .Where(r => r.EmailOfDoctor == email)
                                                 .ToListAsync();
                return Ok(reservations);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReservation(int id)
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
