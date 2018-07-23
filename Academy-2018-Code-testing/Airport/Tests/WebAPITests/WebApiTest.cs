

using DAL;
using DAL.Repository.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebAPITests
{
    [TestFixture]
    public class WebAPITests
    {
        private readonly TestServer server;
        private readonly HttpClient client;
        private FlightDTO F1 { get; set; }
        private Ticket ticketIn { get; set; }
        private TicketDTO ticketOut { get; set; }

        

        public WebAPITests()
        {
            server = new TestServer(new WebHostBuilder()
                            .UseEnvironment("Testing")
                            .UseStartup<Startup>());
            client = server.CreateClient();
            
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
        public async Task Tickets_Should_Get_All()
        {
            // Act
            var response = await client.GetAsync("/api/Tickets");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<TicketDTO>>(responseString);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(tickets.Count() > 0);
        }

        [Test]
        public async Task Tickets_Should_Get_Specific()
        {
            // Arrange
            var responseForArrange = await client.GetAsync("/api/Tickets");
            responseForArrange.EnsureSuccessStatusCode();
            var responseStringForArrange = await responseForArrange.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<TicketDTO>>(responseStringForArrange);

            // Act
            var response = await client.GetAsync($"/api/Tickets/{tickets[tickets.Count() - 1].Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var ticket = JsonConvert.DeserializeObject<FlightDTO>(responseString);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(tickets[tickets.Count() - 1].Id, ticket.Id);
        }

        [Test, Order(1)]
        public async Task Tickets_Should_Post_Specific()
        {
            // Arrange
            
            var content = JsonConvert.SerializeObject(ticketIn);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Tickets", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var Out = JsonConvert.DeserializeObject<FlightDTO>(responseString);

            Assert.AreEqual(ticketIn.FlightNumber, Out.Number);
        }

        [Test]
        public async Task Tickets_Post_Specific_Invalid()
        {
            // Arrange
            var ticketToPost = new TicketDTO { FlightNumber = "sdasdasdasdasdasdasdasdasd" };
            var content = JsonConvert.SerializeObject(ticketToPost);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Tickets", stringContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Tickets_Put_Specific()
        {
            // Arrange
            var responseForArrange = await client.GetAsync("/api/Tickets");
            responseForArrange.EnsureSuccessStatusCode();
            var responseStringForArrange = await responseForArrange.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<TicketDTO>>(responseStringForArrange);

            var ticketChanged = new TicketDTO
            {
                Price = 1000
            };
            var content = JsonConvert.SerializeObject(ticketChanged);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/api/Tickets/{tickets[tickets.Count() - 1].Id}", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var ticket = JsonConvert.DeserializeObject<TicketDTO>(responseString);

            Assert.AreEqual(ticketChanged.Price, ticket.Price);
        }

        [Test]
        public async Task Tickets_Put_Specific_Invalid()
        {
            // Arrange
            var flightToChange = new TicketDTO { Price = -1111 };
            var content = JsonConvert.SerializeObject(flightToChange);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/api/Tickets/-1111", stringContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Test, Order(7)]
        public async Task Tickets_Delete_Specific()
        {
            // Arrange
            var responseGet = await client.GetAsync("/api/Tickets");
            responseGet.EnsureSuccessStatusCode();
            var responseString = await responseGet.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<TicketDTO>>(responseString);

            // Act
            var response = await client.DeleteAsync($"/api/Tickets/{tickets[tickets.Count() - 1].Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
