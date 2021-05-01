using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface ILeaseholderRepository
    {
        Task<IEnumerable<Leaseholder>> ListAsync();
    }
}
