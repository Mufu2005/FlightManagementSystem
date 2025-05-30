using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Data;

namespace UserService.Data
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
