using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HotelReservation.Authendication;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Data
{
    public class ModelDbContext :DbContext
    {
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {
        }


        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Reservation> resevations { get; set; }
        public DbSet<Room_Details> rooms { get; set; }
        public DbSet<User> users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        internal Task<ActionResult<IEnumerable<Hotel>>> Gethotels()
        {
            throw new NotImplementedException();
        }

        public DbSet<HotelReservation.Authendication.Login> Login { get; set; } = default!;
    }
}
