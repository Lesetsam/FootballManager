using FootballManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Application.Interfaces.Repositories
{
    public interface IPlayerRepositoryAsync : IGenericRepositoryAsync<Player>
    {
        Task<bool> IsUniqueIdNoAsync(int idNo);
    }
}
