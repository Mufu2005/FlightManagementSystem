using Microsoft.EntityFrameworkCore;
using CheckInService.Models;

namespace CheckInService.Data
{
    public class CheckInDbContext : DbContext
    {
        public CheckInDbContext(DbContextOptions<CheckInDbContext> options)
            : base(options) { }

        public DbSet<CheckIn> CheckIns { get; set; }
    }
}
