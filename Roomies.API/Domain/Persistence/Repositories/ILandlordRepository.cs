using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface ILandlordRepository
    {
        Task<IEnumerable<Leaseholder>> ListAsync();
        Task<Leaseholder> FindById(string id);
        Task AddAsync(Leaseholder landlord);
        void Update(Leaseholder landlord);
        void Remove(Leaseholder landlord);
    }
}
