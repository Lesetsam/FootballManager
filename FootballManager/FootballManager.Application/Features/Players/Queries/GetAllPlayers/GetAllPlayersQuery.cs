
using AutoMapper;
using FootballManager.Application.Features.Players.Queries.GetAllPlayers;
using FootballManager.Application.Filters;
using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Players.Queries.GetAllPlayers
{
    public class GetAllPlayersQuery : IRequest<PagedResponse<IEnumerable<GetAllPlayersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, PagedResponse<IEnumerable<GetAllPlayersViewModel>>>
    {
        private readonly IPlayerRepositoryAsync _playerRepository;
        private readonly IMapper _mapper;
        public GetAllPlayersQueryHandler(IPlayerRepositoryAsync playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPlayersViewModel>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestParameter>(request);
            var player = await _playerRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var playerViewModel = _mapper.Map<IEnumerable<GetAllPlayersViewModel>>(player);
            return new PagedResponse<IEnumerable<GetAllPlayersViewModel>>(playerViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}