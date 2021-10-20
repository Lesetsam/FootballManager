using AutoMapper;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using FootballManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballManager.Application.Features.Teams.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<TeamPlayerAssignment> Players { get; set; }
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreateTeamCommand, Response<int>>
    {
        private readonly ITeamRepositoryAsync _teamRepository;
        private readonly IMapper _mapper;
        public CreatePlayerCommandHandler(ITeamRepositoryAsync playerRepository, IMapper mapper)
        {
            _teamRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _mapper.Map<Team>(request);
            await _teamRepository.AddAsync(team);
            return new Response<int>(team.Id);
        }
    }
}
