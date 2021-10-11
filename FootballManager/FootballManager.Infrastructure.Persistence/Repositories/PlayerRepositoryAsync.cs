using FootballManager.Application.Interfaces.Repositories;
using FootballManager.Domain.Entities;
using FootballManager.Infrastructure.Persistence.Contexts;
using FootballManager.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Infrastructure.Persistence.Repositories
{
    public class PlayerRepositoryAsync : GenericRepositoryAsync<Player>, IPlayerRepositoryAsync
    {
        private readonly DbSet<Player> _players;

        public PlayerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _players = dbContext.Set<Player>();
        }

        public Task<bool> IsUniqueIdNoAsync(Int64 idNo)
        {
            return _players
                .AllAsync(p => p.IdNo != idNo);
        }
    }
}
