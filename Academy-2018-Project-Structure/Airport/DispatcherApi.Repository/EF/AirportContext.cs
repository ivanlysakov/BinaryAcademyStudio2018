using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;


using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.EF
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {


        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<AirplaneType> AirplaneTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().ToTable("Airplanes");
            modelBuilder.Entity<AirplaneType>().ToTable("AirplaneTypes");
            
        }


    }
}
