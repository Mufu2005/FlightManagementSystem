using Microsoft.EntityFrameworkCore;
using FlightService.Models;

namespace FlightService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Flight> Flights { get; set; }
}