using FootballManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Application.Interfaces.Repositories
{
    public interface ITeamRepositoryAsync : IGenericRepositoryAsync<Team>
    {
        Task<bool> IsUniqueNameAsync(string name);
    }
}
