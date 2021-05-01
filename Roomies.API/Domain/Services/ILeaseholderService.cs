using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface ILeaseholderService
    {
        Task<IEnumerable<Leaseholder>> ListAsync();
        Task<IEnumerable<Leaseholder>> ListByPostIdAsync(string postId);
        Task<LeaseholderResponse> GetByIdAsync(string id);
        Task<LeaseholderResponse> SaveAsync(Leaseholder landlord);
        Task<LeaseholderResponse> UpdateAsync(string id, Leaseholder landlord);
        Task<LeaseholderResponse> DeleteAsync(string id);
    }
}
