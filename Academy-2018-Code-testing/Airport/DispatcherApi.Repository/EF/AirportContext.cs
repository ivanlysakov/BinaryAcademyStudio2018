using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.EF
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {
         
            Database.EnsureCreated();

        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<AirplaneType> AirplaneTypes { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Hostess> Hostesses { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight > Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //так і не розібрався((((

           // modelBuilder.Entity<Hostess>()
            //    .HasOne(e => e.Crew)
             //   .WithMany(c => c.Hostesses);



        }


    }
}
