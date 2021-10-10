using AutoMapper;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using FootballManager.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Players.Commands.CreatePlayer
{
    public partial class CreatePlayerCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int IdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Response<int>>
    {
        private readonly IPlayerRepositoryAsync _playerRepository;
        private readonly IMapper _mapper;
        public CreatePlayerCommandHandler(IPlayerRepositoryAsync playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = _mapper.Map<Player>(request);
            await _playerRepository.AddAsync(player);
            return new Response<int>(player.Id);
        }
    }
}
