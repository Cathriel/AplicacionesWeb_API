using Roomies.API.Domain.Models;
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
    }
}
