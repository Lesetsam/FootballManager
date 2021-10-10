using FootballManager.Application.Exceptions;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Players.Commands.DeletePlayerById
{
    public class DeletePlayerByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeletePlayerByIdCommandHandler : IRequestHandler<DeletePlayerByIdCommand, Response<int>>
        {
            private readonly IPlayerRepositoryAsync _playerRepository;
            public DeletePlayerByIdCommandHandler(IPlayerRepositoryAsync playerRepository)
            {
                _playerRepository = playerRepository;
            }
            public async Task<Response<int>> Handle(DeletePlayerByIdCommand command, CancellationToken cancellationToken)
            {
                var player = await _playerRepository.GetByIdAsync(command.Id);
                if (player == null) throw new ApiException($"Player Not Found.");
                await _playerRepository.DeleteAsync(player);
                return new Response<int>(player.Id);
            }
        }
    }
}
