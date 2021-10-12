using FluentAssertions;
using FootballManager.Application.Exceptions;
using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Application.Features.Players.Commands.UpdatePlayer;
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
    public class UpdatePlayerTests : TestBase
    {
        [Test]
        public void ShouldRequireValidPlayerId()
        {
            var command = new UpdatePlayerCommand
            {
                Id = 99,
                IdNo = 1234569874253
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdatePlayer()
        {
            var userId = await RunAsDefaultUserAsync();

            var itemId = await SendAsync(new CreatePlayerCommand
            {
                FirstName = "Name",
                Surname = "LastName",
                DateOfBirth = DateTime.Now,
                IdNo = 012346789102,
                Height = 65.5M,
                Weight = 71.5M
            });

            var command = new UpdatePlayerCommand
            {
                Id = itemId.Data,
                FirstName = "Updated Name",
                Surname = "Updated LastName",
                DateOfBirth = DateTime.Now,
                IdNo = 012346789102,
                Height = 65.5M,
                Weight = 71.5M
            };

            await SendAsync(command);

            var item = await FindAsync<Player>(itemId);

            item.FirstName.Should().Be(command.FirstName);
            item.Surname.Should().Be(command.Surname);
            item.DateOfBirth.Should().Be(command.DateOfBirth);
            item.IdNo.Should().Be(command.IdNo);
            item.Height.Should().Be(command.Height);
            item.Weight.Should().Be(command.Weight);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(1000));
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
