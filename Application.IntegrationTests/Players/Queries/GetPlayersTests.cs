using Application.Features.Players.Queries.GetAllPlayers;
using FluentAssertions;
using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Players.Queries
{
    using static Testing;
    public class GetPlayersTests : TestBase
    {
        

        [Test]
        public async Task ShouldReturnAllPlayers()
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

            var query = new GetAllPlayersQuery();

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(1);
        }
    }
}
