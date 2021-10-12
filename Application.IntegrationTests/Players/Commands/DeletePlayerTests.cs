using FluentAssertions;
using FootballManager.Application.Exceptions;
using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Application.Features.Players.Commands.DeletePlayerById;
using FootballManager.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Players.Commands
{
    using static Testing;
    public class DeletePlayerTests : TestBase
    {
        [Test]
        public void ShouldRequireValidPlayerId()
        {
            var command = new DeletePlayerByIdCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeletePlayer()
        {

            var itemId = await SendAsync(new CreatePlayerCommand
            {
                FirstName = "Name",
                Surname = "LastName",
                DateOfBirth = DateTime.Now,
                IdNo = 012346789102,
                Height = 65.5M,
                Weight = 71.5M
            });

            await SendAsync(new DeletePlayerByIdCommand
            {
                Id = itemId.Data
            });

            var item = await FindAsync<Player>(itemId);

            item.Should().BeNull();
        }
    }
}
