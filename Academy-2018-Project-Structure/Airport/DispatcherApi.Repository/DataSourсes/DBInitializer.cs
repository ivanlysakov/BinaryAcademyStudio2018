using DAL.Repository.EF;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.DataSourсes
{
   public class DBInitializer
    {
        


        public static void Initialize(AirportContext context)
        {

           var Airplanes = GetAirplanes();





            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Airplanes.Any())
            {
                return;   // DB has been seeded
            }

          
            foreach (var plane in Airplanes)
            {
                context.Airplanes.Add(plane);
            }
            context.SaveChanges();

            
        }

        private static List<Airplane> GetAirplanes()
        {
            var plane1 = new Airplane
            {
                Id = 1,
                Name = "UR-43545",
                CreationDate = new DateTime(2012, 6, 14),
                Lifetime = new TimeSpan(1825, 0, 0, 0)
            };
            plane1.Type = new AirplaneType
            {
                Id = 1,
                Model = "Boing 747-100",
                Capacity = 370,
                Cargo = 16000,
                Speed = 917,
                FlightRange = 7163
            };

            var plane2 = new Airplane
            {
                Id = 2,
                Name = "UR-13256",
                CreationDate = new DateTime(2014, 5, 15),
                Lifetime = new TimeSpan(1, 0, 0, 0)
            };
            plane2.Type = new AirplaneType
            {
                Id = 2,
                Model = "Airbus A320-200",
                Capacity = 266,
                Cargo = 2000,
                Speed = 917,
                FlightRange = 3717
            };

            var plane3 = new Airplane
            {
                Id = 3,
                Name = "UR-23200",
                CreationDate = new DateTime(2015, 7, 10),
                Lifetime = new TimeSpan(1825, 0, 0, 0)
            };
            plane3.Type = new AirplaneType
            {
                Id = 3,
                Model = "Boing 747-200",
                Capacity = 126,
                Cargo = 20000,
                Speed = 853,
                FlightRange = 9850
            };

            var plane4 = new Airplane
            {
                Id = 4,
                Name = "UR-88888",
                CreationDate = new DateTime(2012, 6, 14),
                Lifetime = new TimeSpan(2555, 0, 0, 0)
            };
            plane4.Type = new AirplaneType
            {
                Id = 4,
                Model = "Boing 737",
                Capacity = 114,
                Cargo = 2400,
                Speed = 793,
                FlightRange = 2518
            };

            return new List<Airplane> { plane1, plane2, plane3, plane4 };
        }
    }
}
