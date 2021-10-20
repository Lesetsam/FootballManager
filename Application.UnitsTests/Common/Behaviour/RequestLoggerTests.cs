using FootballManager.Application.Features.Players.Commands.CreatePlayer;
using FootballManager.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitsTests.Common.Behaviour
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreatePlayerCommand>> _logger;
        private readonly Mock<IAuthenticatedUserService> _currentUserService;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreatePlayerCommand>>();

            _currentUserService = new Mock<IAuthenticatedUserService>();
        }
    }
}
