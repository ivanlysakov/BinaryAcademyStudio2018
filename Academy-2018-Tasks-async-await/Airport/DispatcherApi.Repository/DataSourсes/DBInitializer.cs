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
            var AirplaneTypes = GetAirplaneTypes();
            var Pilots = GetPilots();
            var Hostesses = GetHostesses();
            var Crews = GetGrews();
            var Tickets = GetTickets();
            var Flights = GetFlights();
            var Departures = GetDepartures();

            context.Database.EnsureCreated();
                 
            
            if (!context.Airplanes.Any())
            {
                foreach (var plane in Airplanes)
                {
                    context.Airplanes.Add(plane);
                }
            }
                                        
            if (!context.AirplaneTypes.Any())
            {
                foreach (var item in AirplaneTypes)
                {
                    context.AirplaneTypes.Add(item);
                }
            }

            if (!context.Crews.Any())
            {
                foreach (var item in Crews)
                {
                    context.Crews.Add(item);
                }
            }


            if (!context.Pilots.Any())
            {
                foreach (var item in Pilots)
                {
                    context.Pilots.Add(item);
                }
            }


            if (!context.Hostesses.Any())
            {
                foreach (var item in Hostesses)
                {
                    context.Hostesses.Add(item);
                }
            }


            if (!context.Tickets.Any())
            {
                foreach (var item in Tickets)
                {
                    context.Tickets.Add(item);
                }
            }


            if (!context.Flights.Any())
            {
                foreach (var item in Flights)
                {
                    context.Flights.Add(item);
                }
            }


            if (!context.Departures.Any())
            {
                foreach (var item in Departures)
                {
                    context.Departures.Add(item);
                }
            }

             context.SaveChanges();
            
        }
                
        public static List<Airplane> GetAirplanes()
        {
            var plane1 = new Airplane
            {
               
                Name = "UR43545",
                CreationDate = new DateTime(2012, 6, 14),
                Lifetime = 3
            };
            plane1.Type = new AirplaneType
            {
                
                Model = "Boing 747-100",
                Capacity = 370,
                Cargo = 16000
                //AirplaneRef = 1

            };

            var plane2 = new Airplane
            {
                
                Name = "UR13256",
                CreationDate = new DateTime(2014, 5, 15),
                Lifetime = 3
            };
            plane2.Type = new AirplaneType
            {
                
                Model = "Airbus A320-200",
                Capacity = 266,
                Cargo = 2000
                //AirplaneRef = 2
              
            };

            var plane3 = new Airplane
            {
                
                Name = "UR23200",
                CreationDate = new DateTime(2015, 7, 10),
                Lifetime = 3
            };
            plane3.Type = new AirplaneType
            {
              
                Model = "Boing 747-200",
                Capacity = 126,
                Cargo = 2000
                //AirplaneRef = 3

            };

            var plane4 = new Airplane
            {
                Name = "UR-88888",
                CreationDate = new DateTime(2012, 6, 14),
                Lifetime = 3
            };
            plane4.Type = new AirplaneType
            {
               
                Model = "Boing 737",
                Capacity = 114,
                Cargo = 2400
                //AirplaneRef = 4

            };

            return new List<Airplane> { plane1, plane2, plane3, plane4 };
        }

        public static List<AirplaneType> GetAirplaneTypes()
        {
            var types = new List<AirplaneType>() { };

            foreach (var item in GetAirplanes())
            {
                types.Add(item.Type);
            }

            return types;
        }

        public static List<Pilot> GetPilots()
        {
            var pilot1 = new Pilot
            {
                
                FirstName = "John",
                Lastname = "Smith",
                BirthDay = new DateTime(1980, 2, 25),
                Experience = 3
            };

            var pilot2 = new Pilot
            {
                
                FirstName = "Paul",
                Lastname = "Umtiti",
                BirthDay = new DateTime(1973, 5, 16),
                Experience = 6
            };

            var pilot3 = new Pilot
            {
                FirstName = "Usman",
                Lastname = "Dembele",
                BirthDay = new DateTime(1985, 2, 15),
                Experience = 5
            };

            return new List<Pilot> { pilot1, pilot2, pilot3 };

        }

        public static List<Hostess> GetHostesses()
        {
            var hostess1 = new Hostess
            {
                
                FirstName = "Martie",
                Lastname = "Rubin",
                BirthDay = new DateTime(1995, 1, 21)

            };
            var hostess2 = new Hostess
            {
               
                FirstName = "Natalie",
                Lastname = "Martins",
                BirthDay = new DateTime(1990, 4, 6)

            };
            var hostess3 = new Hostess
            {
                
                FirstName = "Kayli",
                Lastname = "Leibnits",
                BirthDay = new DateTime(1989, 6, 25)

            };
            var hostess4 = new Hostess
            {
               
                FirstName = "Mery",
                Lastname = "Poppins",
                BirthDay = new DateTime(1993, 11, 12)

            };
            return new List<Hostess> { hostess1, hostess2, hostess3, hostess4 };
        }

        public static List<Crew> GetGrews()
        {
            var crew1 = new Crew
            {
             
                Pilot = GetPilots().Where(x => x.Lastname == "Umtiti").Single(),
                Hostesses = new List<Hostess>() {
                    GetHostesses().Where(x => x.FirstName == "Martie").Single(),
                    GetHostesses().Where(x => x.FirstName == "Mery").Single(),
                }
            };


            var crew2 = new Crew
            {
             
                Pilot = GetPilots().Where(x => x.Lastname == "Dembele").Single(),
                Hostesses = new List<Hostess>() {
                    GetHostesses().Where(x => x.FirstName == "Kayli").Single(),
                    GetHostesses().Where(x => x.FirstName == "Natalie").Single(),
                }
            };
            return new List<Crew> { crew1, crew2 };
        }

        public static List<Flight> GetFlights()
        {
            var flight1 = new Flight
            {
               
                Number = "PS177",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(1, 13, 0),
                Destination = "Washington",
                ArrivalTime = DateTime.Now + new TimeSpan(6, 15, 0),
                Tickets = GetTickets().Where(t => t.FlightNumber == "PS177")?.ToList()

            };


            var flight2 = new Flight
            {
               
                Number = "PS101",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(0, 45, 45),
                Destination = "Paris",
                ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
                Tickets = GetTickets().Where(t => t.FlightNumber == "PS101").ToList()

            };

            var flight3 = new Flight
            {
            
                Number = "PS161",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(1, 20, 30),
                Destination = "Madrid",
                ArrivalTime = DateTime.Now + new TimeSpan(4, 40, 15),
                Tickets = GetTickets().Where(t => t.FlightNumber == "PS161").ToList()

            };
            return new List<Flight> { flight1, flight2, flight3 };
        }

        public static List<Departure> GetDepartures()
        {
            var dep1 = new Departure
            {
                
                FlightNumber = "PS101",
                Airplane = GetAirplanes().Where(x => x.Name == "UR23200").Single(),
                Time = DateTime.Now + new TimeSpan(0, 45, 45),
            };


            var dep2 = new Departure
            {
              
                FlightNumber = "PS161",
                Airplane = GetAirplanes().Where(x => x.Name == "UR43545").Single(),
                Time = DateTime.Now + new TimeSpan(0, 1, 15),

            };

            return new List<Departure> { dep1, dep2, };
        }

        public static List<Ticket> GetTickets()
        {
            var ticket1 = new Ticket
            {

             
                FlightNumber = "PS101",
                Price = 99

            };

            var ticket2 = new Ticket
            {

              
                FlightNumber = "PS101",
                Price = 99

            };

            var ticket3 = new Ticket
            {

                FlightNumber = "PS161",
                Price = 150

            };

            var ticket4 = new Ticket
            {

            
                FlightNumber = "PS161",
                Price = 150

            };
            var ticket5 = new Ticket
            {

              
                FlightNumber = "PS177",
                Price = 150

            };



            return new List<Ticket> { ticket1, ticket2, ticket3, ticket4, ticket5 };
        }

    }
}
