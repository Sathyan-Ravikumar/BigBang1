using HotelReservation.Authendication;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Login> logins { get; set; }
    }
}
