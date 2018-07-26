
using BL.Service.Interfaces;
using DAL.Controllers;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Tests
{
    [TestFixture]
    public class TicketsControllerTests
    {
        private FlightDTO F1 { get; set; }
        private TicketDTO ticket1In { get; set; }
        private TicketDTO ticket2In { get; set; }
        private TicketDTO ticketOut { get; set; }

        public TicketsControllerTests() 
            
            { 
            
            F1 = new FlightDTO
            {
                Number = "PS101",
                Departure = "London",
                DepartureTime = DateTime.Now + new TimeSpan(0, 30, 45),
                Destination = "Paris",
                ArrivalTime = DateTime.Now + new TimeSpan(3, 15, 0),
            };
            ticket1In = new TicketDTO { Id = 1, FlightNumber = "PS101", Price = 300, FlightId = F1.Id };
            ticket2In = new TicketDTO { Id = 1, FlightNumber = "PS101", Price = 300, FlightId = F1.Id };
            ticketOut = new TicketDTO { Id = 1, FlightNumber = "PS101", Price = 400, FlightId = F1.Id };
        }
        

        [Test]
        public void Get_Should_get_all_tickets()
        {
            // Arrange
       
            var ticketservice = A.Fake<ITicketsService>();
            A.CallTo(() => ticketservice.Get()).Returns(new List<TicketDTO> { ticket1In, ticket2In });
            var ticketsController = new TicketsController(ticketservice);

            //Act
            var actionResult = ticketsController.GetAll();

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            List<TicketDTO> tickets = result.Value as List<TicketDTO>;

            Assert.AreEqual(2, tickets.Count());
            Assert.AreEqual(ticket1In, tickets[0]);
            Assert.AreEqual(ticket2In, tickets[1]);
        }

        [Test]
        public void Get_Should_get_flight_by_id()
        {
            // Arrange
            
            var ticketservice = A.Fake<ITicketsService>();

            A.CallTo(() => ticketservice.GetById(A<int>._)).Returns(ticket1In);

            var ticketsController = new TicketsController(ticketservice);

            //Act
            var actionResult = ticketsController.Get(1);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            TicketDTO ticketDTOResult = result.Value as TicketDTO;

            Assert.AreEqual(ticket1In, ticketDTOResult);
        }

        [Test]
        public void Post_Should_create_new_ticket_return_statusCode_200()
        {
            // Arrange
           
            var ticketservice = A.Fake<ITicketsService>();
            var ticketsController = new TicketsController(ticketservice);

            //Act
            var actionResult = ticketsController.Post(ticket1In);

            //Assert
            Assert.NotNull(actionResult);
            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void Put_Should_change_existing_ticket_return_statusCode_200()
        {

            // Arrange
                     
            var ticketservice = A.Fake<ITicketsService>();

            A.CallTo(() => ticketservice.GetById(A<int>._)).Returns(ticket1In);
            
            var ticketsController = new TicketsController(ticketservice);


            //Act
            var actionResult = ticketsController.Put(ticketOut, 1);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        
        [Test]
        public void Delete_Should_delete_ticket_by_id_return_statusCode_204()
        {
            // Arrange

            var ticketservice = A.Fake<ITicketsService>();

            A.CallTo(() => ticketservice.GetById(A<int>._)).Returns(ticket1In);

            var ticketsController = new TicketsController(ticketservice);

            //Act
            var actionResult = ticketsController.Delete(1);

            //Assert
            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }

    }
}
