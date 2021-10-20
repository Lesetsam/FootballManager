using FluentAssertions;
using FluentAssertions.Extensions;
using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Domain.Entities;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.Players.Commands
{
    using static Testing;
    public class CreatePlayerTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePlayerCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreatePlayer()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreatePlayerCommand
            {
                FirstName = "Name",
                Surname = "LastName",
                DateOfBirth = DateTime.Now,
                IdNo = 012346789102,
                Height = 65.5M,
                Weight = 71.5M
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Player>(itemId.Data);

            item.Should().NotBeNull();
            item.FirstName.Should().Be(command.FirstName);
            item.Surname.Should().Be(command.Surname);
            item.DateOfBirth.Should().Be(command.DateOfBirth);
            item.IdNo.Should().Be(command.IdNo);
            item.Height.Should().Be(command.Height);
            item.Weight.Should().Be(command.Weight);
            item.CreatedBy.Should().Be(userId);
            //item.Created.Should().BeCloseTo(DateTime.Now, 0.5.Seconds());
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
