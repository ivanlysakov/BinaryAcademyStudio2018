using BL.Service.Services;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using FakeItEasy;
using NUnit.Framework;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Helpers;

namespace Tests.ServicesTests
{
    [TestFixture]
    public class TicketServiceTests
    {

        private FlightDTO F1 { get; set; }
        private Ticket ticketIn { get; set; }
        private TicketDTO ticketOut { get; set; }
    

        public TicketServiceTests()

        {
            F1 = new FlightDTO
            {
                Number = "PS101",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(0, 30, 45),
                Destination = "Paris",
                ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
            };
            ticketOut = new TicketDTO { Id = 1, FlightNumber = "PS101", Price = 400, FlightId = F1.Id };
            ticketIn = new Ticket { Id = 1, FlightNumber = "PS101", Price = 400, FlightId = F1.Id };
        }

        [Test]
        public void CreateEntity_Should_Create_ticket_typeof_Ticket()
        {
            // Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            
            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(()=>unitOfWorkFactory.Create()).Returns(unitOfWork);
           
            var ticketRepository = new FakeRepository<Ticket>();
            
            A.CallTo(() => unitOfWork.Repository<Ticket>().Create(ticketIn));
            var result = unitOfWork.Repository<Ticket>().Get(1);

            // Assert
            Assert.AreEqual(ticketIn, result);

        }

    }
}
