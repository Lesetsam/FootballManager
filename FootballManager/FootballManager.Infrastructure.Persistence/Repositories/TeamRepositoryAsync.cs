using FootballManager.Application.Interfaces;
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
    public class TeamRepositoryAsync : GenericRepositoryAsync<Team>, ITeamRepositoryAsync
    {
        private readonly DbSet<Team> _teams;

        public TeamRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _teams = dbContext.Set<Team>();
        }

        public Task<bool> IsUniqueNameAsync(string name)
        {
            return _teams
                .AllAsync(p => p.Name != name);
        }
    }
}
