using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext context;
        private readonly Mock<ILoggedInUserService> loggedInUserServiceMock;
        private readonly string loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            this.loggedInUserId = "00000000-0000-0000-0000-000000000000";
            this.loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            this.loggedInUserServiceMock.Setup(m => m.UserId).Returns(this.loggedInUserId);

            this.context = new GloboTicketDbContext(dbContextOptions, this.loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test Event" };

            this.context.Events.Add(ev);
            await this.context.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(this.loggedInUserId);
        }
    }
}
