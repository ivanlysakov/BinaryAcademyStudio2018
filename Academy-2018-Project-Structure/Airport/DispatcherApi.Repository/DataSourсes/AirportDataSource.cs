using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.DataSourсes
{
    public class AirportDataSource
    {
        public List<Airplane> Airplanes { get; set; }
        public List<AirplaneType> AirplaneTypes { get; set; }
        public List<Crew> Crews { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Hostess> Hostesses { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Departure> Departures { get; set; }
        
        public AirportDataSource()
        {
            Airplanes = GetAirplanes();
            AirplaneTypes = GetAirplaneTypes();
            Pilots = GetPilots();
            Hostesses = GetHostesses();
            Crews = GetGrews();
            Tickets = GetTickets();
            Flights = GetFlights();
            Departures = GetDepartures();
            
        }

         List<Airplane> GetAirplanes()
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

         List<AirplaneType> GetAirplaneTypes()
        {
            var types = new List<AirplaneType>() { };

            foreach (var item in GetAirplanes())
            {
                types.Add(item.Type);
            }

            return types;
        }

         List<Pilot> GetPilots()
        {
            var pilot1 = new Pilot
            {
                Id = 1,
                FirstName = "John",
                Lastname = "Smith",
                BirthDay = new DateTime(1980, 2, 25),
                Experience = new TimeSpan(1820, 0, 0, 0)
            };

            var pilot2 = new Pilot
            {
                Id = 2,
                FirstName = "Paul",
                Lastname = "Umtiti",
                BirthDay = new DateTime(1973, 5, 16),
                Experience = new TimeSpan(3650, 0, 0, 0)
            };

            var pilot3 = new Pilot
            {
                Id = 3,
                FirstName = "Usman",
                Lastname = "Dembele",
                BirthDay = new DateTime(1985, 2, 15),
                Experience = new TimeSpan(1825, 0, 0, 0)
            };

            return new List<Pilot> { pilot1, pilot2, pilot3 };

        }

         List<Hostess> GetHostesses()
        {
            var hostess1 = new Hostess
            {
                Id = 1,
                FirstName = "Martie",
                Lastname = "Rubin",
                BirthDay = new DateTime(1995, 1, 21)

            };
            var hostess2 = new Hostess
            {
                Id = 2,
                FirstName = "Natalie",
                Lastname = "Martins",
                BirthDay = new DateTime(1990, 4, 6)

            };
            var hostess3 = new Hostess
            {
                Id = 3,
                FirstName = "Kayli",
                Lastname = "Leibnits",
                BirthDay = new DateTime(1989, 6, 25)

            };
            var hostess4 = new Hostess
            {
                Id = 4,
                FirstName = "Mery",
                Lastname = "Poppins",
                BirthDay = new DateTime(1993, 11, 12)

            };
            return new List<Hostess> { hostess1, hostess2, hostess3, hostess4 };
        }

         List<Crew> GetGrews()
        {
            var crew1 = new Crew
            {
                Id = 1,
                Pilot = GetPilots().Where(x => x.Id == 2).Single(),
                Hostesses = new List<Hostess>() {
                    GetHostesses().Where(x => x.Id == 2).Single(),
                    GetHostesses().Where(x => x.Id == 3).Single(),
                }
            };


            var crew2 = new Crew
            {
                Id = 2,
                Pilot = GetPilots().Where(x => x.Id == 3).Single(),
                Hostesses = new List<Hostess>() {
                    GetHostesses().Where(x => x.Id == 1).Single(),
                    GetHostesses().Where(x => x.Id == 4).Single(),
                }
            };
            return new List<Crew> { crew1,crew2};
        }

         List<Flight> GetFlights()
        {
            var flight1 = new Flight
            {
                Id = 1,
                Number = "PS177",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(1, 13, 0),
                Destination = "Washington",
                ArrivalTime = DateTime.Now + new TimeSpan(6, 15, 0),
                Tickets = Tickets.Where(t => t.FlightNumber == "PS177")?.ToList()

            };


            var flight2 = new Flight
            {
                Id = 2,
                Number = "PS101",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(0, 45, 45),
                Destination = "Paris",
                ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
                Tickets = Tickets.Where(t => t.FlightNumber == "PS101").ToList()

            };

            var flight3 = new Flight
            {
                Id = 3,
                Number = "PS161",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(1, 20, 30),
                Destination = "Madrid",
                ArrivalTime = DateTime.Now + new TimeSpan(4, 40, 15),
                Tickets = Tickets.Where(t => t.FlightNumber == "PS161").ToList()

            };
            return new List<Flight> { flight1, flight2, flight3 };
        }

         List<Departure> GetDepartures()
        {
            var dep1 = new Departure
            {
                Id = 1,
                FlightNumber = "PS101",
                Airplane = GetAirplanes().Where(x => x.Id == 2).Single(),
                Crew = GetGrews().Where(x => x.Id == 2).Single(),
                Time = DateTime.Now + new TimeSpan(0, 45, 45),
                

            };


            var dep2 = new Departure
            {
                Id = 2,
                FlightNumber = "PS161",
                Airplane = GetAirplanes().Where(x => x.Id == 1).Single(),
                Crew = GetGrews().Where(x => x.Id == 1).Single(),
                Time = DateTime.Now + new TimeSpan(0, 1, 15),
                
            };

            return new List<Departure> { dep1, dep2, };
        }

         List<Ticket> GetTickets()
        {
            var ticket1 = new Ticket
            {

                Id = 1,
                FlightNumber = "PS101",
                Price = 99

            };

            var ticket2 = new Ticket
            {

                Id = 2,
                FlightNumber = "PS101",
                Price = 99

            };
                        
            var ticket3 = new Ticket
            {

                Id = 3,
                FlightNumber = "PS161",
                Price = 150

            };

            var ticket4 = new Ticket
            {

                Id = 4,
                FlightNumber = "PS161",
                Price = 150

            };
            var ticket5 = new Ticket
            {

                Id = 5,
                FlightNumber = "PS177",
                Price = 150

            };



            return new List<Ticket> { ticket1, ticket2, ticket3, ticket4, ticket5 };
        }










    }
}
