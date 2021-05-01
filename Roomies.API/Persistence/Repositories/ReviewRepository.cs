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
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review> FindById(string id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListByLandlordId(string landlordId)
        {

            return await _context.Reviews
               .Where(p => p.LandlordId == landlordId)
               .Include(p => p.Landlord)
               .ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListByLeaseholderId(string leaseholderId)
        {
            return await _context.Reviews
               .Where(p => p.LeaseholderId == leaseholderId)
               .Include(p => p.Leaseholder)
               .ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListByPostId(string postId)
        {
            return await _context.Reviews
                .Where(p => p.PostId == postId)
                .Include(p => p.Post)
                .ToListAsync();
        }

        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
    }
}
