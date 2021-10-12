using FootballManager.Application.Exceptions;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using FootballManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Players.Queries.GetPlayerById
{
    public class GetPlayerByIdQuery : IRequest<Response<Player>>
    {
        public int Id { get; set; }
        public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Response<Player>>
        {
            private readonly IPlayerRepositoryAsync _playerRepository;
            public GetPlayerByIdQueryHandler(IPlayerRepositoryAsync playerRepository)
            {
                _playerRepository = playerRepository;
            }
            public async Task<Response<Player>> Handle(GetPlayerByIdQuery query, CancellationToken cancellationToken)
            {
                var player = await _playerRepository.GetByIdAsync(query.Id);
                if (player == null) throw new ApiException($"Player Not Found.");
                return new Response<Player>(player);
            }
        }
    }
}
