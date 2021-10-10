using FootballManager.Application.Exceptions;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int IdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Response<int>>
        {
            private readonly IPlayerRepositoryAsync _playerRepository;
            public UpdatePlayerCommandHandler(IPlayerRepositoryAsync playerRepository)
            {
                _playerRepository = playerRepository;
            }
            public async Task<Response<int>> Handle(UpdatePlayerCommand command, CancellationToken cancellationToken)
            {
                var player = await _playerRepository.GetByIdAsync(command.Id);

                if (player == null)
                {
                    throw new ApiException($"Player Not Found.");
                }
                else
                {
                    player.FirstName = command.FirstName;
                    player.Surname = command.Surname;
                    player.IdNo = command.IdNo;
                    player.DateOfBirth = command.DateOfBirth;
                    player.Height = command.Height;
                    player.Weight = command.Weight;

                    await _playerRepository.UpdateAsync(player);
                    return new Response<int>(player.Id);
                }
            }
        }
    }
}
