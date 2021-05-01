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

        public async Task AddAsync(Leaseholder landlord)
        {
            await _context.Landlords.AddAsync(landlord);
        }

        public async Task<Leaseholder> FindById(string id)
        {
            return await _context.Landlords.FindAsync(id);
        }

        public async Task<IEnumerable<Leaseholder>> ListAsync()
        {
            return await _context.Landlords.ToListAsync();
        }

        public void Remove(Leaseholder landlord)
        {
            _context.Landlords.Remove(landlord);
        }

        public void Update(Leaseholder landlord)
        {
            _context.Landlords.Update(landlord);
        }
    }
}
