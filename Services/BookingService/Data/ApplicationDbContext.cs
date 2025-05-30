using Microsoft.EntityFrameworkCore;
using BookingService.Models;
using System.Collections.Generic;

namespace BookingService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Booking> Bookings { get; set; }
}