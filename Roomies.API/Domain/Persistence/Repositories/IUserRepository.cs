using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByPlanId(int planId);
        Task<User> FindById(int id);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
