using Microsoft.EntityFrameworkCore;
using Roomies.API.Domain.Models;
using Roomies.API.Domain.Persistence.Contexts;
using Roomies.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Persistence.Repositories
{
    public class LeaseholderRepository : BaseRepository, ILeaseholderRepository
    {
        public LeaseholderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Leaseholder>> ListAsync()
        {
            return await _context.Leaseholders.ToListAsync();
        }
    }
}
