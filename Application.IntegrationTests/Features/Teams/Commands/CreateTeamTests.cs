using FluentAssertions;
using FluentAssertions.Extensions;
using FootballManager.Application.Features.Teams.Commands.CreateTeam;
using FootballManager.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.Teams.Commands
{
    using static Testing;
    public class CreateTeamTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateTeamCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTeam()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateTeamCommand
            {
                Name = "Name",
                City = "City Name"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Team>(itemId.Data);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.City.Should().Be(command.City);
            item.CreatedBy.Should().Be(userId);
            //item.Created.Should().BeCloseTo(DateTime.Now, 0.5.Seconds());
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
            //item.FirstValid.Should().BeCloseTo(DateTime.Now, 0.5.Seconds());
            item.LastValid.Should().Be(new DateTime(9999,1,1));

        }
    }
}
