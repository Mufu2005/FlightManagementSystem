using Microsoft.AspNetCore.Mvc;
using FlightService.Data;
using FlightService.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FlightController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/flight
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
    {
        return await _context.Flights.ToListAsync();
    }

    // GET: api/flight/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Flight>> GetFlight(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        return flight == null ? NotFound() : flight;
    }

    // POST: api/flight
    [HttpPost]
    public async Task<ActionResult<Flight>> CreateFlight(Flight flight)
    {
        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
    }

    // PUT: api/flight/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFlight(int id, Flight flight)
    {
        if (id != flight.Id)
            return BadRequest();

        _context.Entry(flight).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/flight/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
            return NotFound();

        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}