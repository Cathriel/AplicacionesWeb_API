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
    public class LandlordRepository : BaseRepository, ILandlordRepository
    {
        public LandlordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Landlord>> ListAsync()
        {
            return await _context.Landlords.ToListAsync();
        }
    }
}
