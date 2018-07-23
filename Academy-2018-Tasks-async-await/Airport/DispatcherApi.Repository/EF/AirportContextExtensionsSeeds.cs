using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.EF
{
    public static class AirportContextExtensionsSeeds
    {
        public static void EnsureDatabaseSeeded(this AirportContext context)
        {
            if (!context.Airplanes.Any())

            {

                Flight f1 = new Flight
                {
                    Number = "PS101",
                    Departure = "London",
                    DepartureTime = DateTime.Now + new TimeSpan(0, 30, 45),
                    Destination = "Paris",
                    ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
                };
                Flight f2 = new Flight
                {
                    Number = "PS177",
                    Departure = "London",
                    DepartureTime = DateTime.Now + new TimeSpan(0, 45, 45),
                    Destination = "New York",
                    ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
                };
                Flight f3 = new Flight
                {
                    Number = "PS166",
                    Departure = "London",
                    DepartureTime = DateTime.Now + new TimeSpan(1, 0, 45),
                    Destination = "Madrid",
                    ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
                };
                context.AddRange(new List<Flight> { f1, f2, f3 });
                context.SaveChanges();


                Ticket t1 = new Ticket { FlightNumber = "PS101", Price = 300, FlightId = f1.Id };
                Ticket t2 = new Ticket { FlightNumber = "PS101", Price = 300, FlightId = f1.Id };
                Ticket t3 = new Ticket { FlightNumber = "PS101", Price = 300, FlightId = f1.Id };
                Ticket t4 = new Ticket { FlightNumber = "PS101", Price = 300, FlightId = f1.Id };
                Ticket t5 = new Ticket { FlightNumber = "PS177", Price = 600, FlightId = f2.Id };
                Ticket t6 = new Ticket { FlightNumber = "PS177", Price = 600, FlightId = f2.Id };
                Ticket t7 = new Ticket { FlightNumber = "PS177", Price = 600, FlightId = f2.Id };
                Ticket t8 = new Ticket { FlightNumber = "PS166", Price = 400, FlightId = f3.Id };
                Ticket t9 = new Ticket { FlightNumber = "PS166", Price = 400, FlightId = f3.Id };
                Ticket t10 = new Ticket { FlightNumber = "PS166", Price = 400, FlightId = f3.Id };

                context.AddRange(new List<Ticket> { t1, t2, t3, t4, t5, t6, t7, t8, t9, t9, t10 });
                context.SaveChanges();

                Departure dep1 = new Departure
                {
                    FlightNumber = "PS101",
                    Time = DateTime.Now + new TimeSpan(1, 15, 0)
                };
                Departure dep2 = new Departure
                {
                    FlightNumber = "PS177",
                    Time = DateTime.Now + new TimeSpan(1, 20, 0)
                };
             

                context.AddRange(new List<Departure> { dep1, dep2 });
                context.SaveChanges();

                Crew crew1 = new Crew { CrewNumber = 222,
                    //DepartureID = dep1.Id
                };
                Crew crew2 = new Crew { CrewNumber = 665,
                   // DepartureID = dep2.Id
                };
               

                context.AddRange(new List<Crew> { crew1, crew2 });
                context.SaveChanges();

                Pilot pilot1 = new Pilot
                {
                    FirstName = "John",
                    Lastname = "Smith",
                    BirthDay = new DateTime(1980, 2, 25),
                    Experience = 8,
                    CrewId = crew1.Id

                };
                Pilot pilot2 = new Pilot
                {
                    FirstName = "Paul",
                    Lastname = "Umtiti",
                    BirthDay = new DateTime(1973, 5, 16),
                    Experience = 6,
                    CrewId = crew2.Id
                };

                context.AddRange(new List<Pilot> { pilot1, pilot2 });
                context.SaveChanges();

                Hostess hostess1 = new Hostess
                {
                    FirstName = "Martie",
                    Lastname = "Rubin",
                    BirthDay = new DateTime(1995, 1, 21),
                    CrewID = crew1.Id
                };
                Hostess hostess2 = new Hostess
                {
                    FirstName = "Natalie",
                    Lastname = "Martins",
                    BirthDay = new DateTime(1990, 4, 6),
                    CrewID = crew1.Id
                };
                Hostess hostess3 = new Hostess
                {
                    FirstName = "Kayli",
                    Lastname = "Leibnits",
                    BirthDay = new DateTime(1989, 6, 25),
                    CrewID = crew2.Id

                };
                Hostess hostess4 = new Hostess
                {

                    FirstName = "Mery",
                    Lastname = "Poppins",
                    BirthDay = new DateTime(1993, 11, 12),
                    CrewID = crew2.Id

                };

                context.AddRange(new List<Hostess> { hostess1, hostess2, hostess3, hostess4 });
                context.SaveChanges();

                Airplane airplane1 = new Airplane
                {
                    Name = "UR77777",
                    CreationDate = new DateTime(2011, 6, 15),
                    Lifetime = 3,
                    DepartureID = dep1.Id

                };
                Airplane airplane2 = new Airplane
                {
                    Name = "UR55555",
                    CreationDate = new DateTime(2013, 1, 20),
                    Lifetime = 4,
                    DepartureID = dep2.Id
                };
              

                context.AddRange(new List<Airplane> { airplane1, airplane2});
                context.SaveChanges();

                AirplaneType type1 = new AirplaneType
                {
                    Model = "Boing 747-100",
                    Capacity = 200,
                    Cargo = 4000,
                    AirplaneId = airplane1.Id

                };
           
                AirplaneType type3 = new AirplaneType
                {
                    Model = "Boing 777",
                    Capacity = 370,
                    Cargo = 20000,
                    AirplaneId = airplane2.Id
                };
                context.AddRange(new List<AirplaneType> { type1, type3 });
                context.SaveChanges();

            }


        }
    }
}
