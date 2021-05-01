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

        public async Task AddAsync(Leaseholder leaseholder)
        {
            await _context.Leaseholders.AddAsync(leaseholder);
        }

        public async Task<Leaseholder> FindById(string id)
        {
            return await _context.Leaseholders.FindAsync(id);
        }

        public async Task<IEnumerable<Leaseholder>> ListAsync()
        {
            return await _context.Leaseholders.ToListAsync();
        }

        public void Remove(Leaseholder leaseholder)
        {
            _context.Leaseholders.Remove(leaseholder);
        }

        public void Update(Leaseholder leaseholder)
        {
            _context.Leaseholders.Update(leaseholder);
        }
    }
}
