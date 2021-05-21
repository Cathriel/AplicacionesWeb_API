using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(string id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(string id, User user);
        Task<UserResponse> DeleteAsync(string id);
    }
}
