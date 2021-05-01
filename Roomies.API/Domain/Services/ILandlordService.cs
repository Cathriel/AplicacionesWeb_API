using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface ILandlordService
    {
        Task<IEnumerable<Leaseholder>> ListAsync();
        Task<LandlordResponse> GetByIdAsync(string id);
        Task<LandlordResponse> SaveAsync(Leaseholder landlord);
        Task<LandlordResponse> UpdateAsync(string id, Leaseholder landlord);
        Task<LandlordResponse> DeleteAsync(string id);

    }
}
