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
    public class FavouritePostRepository : BaseRepository, IFavouritePostRepository
    {
        public FavouritePostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FavouritePost favouritePost)
        {
            await _context.FavouritePosts.AddAsync(favouritePost);
        }

        public async Task AssignFavouritePostAsync(string postId, string leaseholderId)
        {
            FavouritePost favouritePost = await FindByPostIdAndLeaseholderId(postId, leaseholderId);
            if (favouritePost == null)
            {
                favouritePost = new FavouritePost { PostId = postId, LeaseholderId = leaseholderId };
                await AddAsync(favouritePost);
            }
        }

        public async Task<FavouritePost> FindByPostIdAndLeaseholderId(string postId, string leaseholderId)
        {
            return await _context.FavouritePosts.FindAsync(postId, leaseholderId);
        }

        public async Task<IEnumerable<FavouritePost>> ListAsync()
        {
            return await _context.FavouritePosts
                .Include(pt => pt.Post)
                .Include(pt => pt.Leaseholder)
                .ToListAsync();
        }

        public async Task<IEnumerable<FavouritePost>> ListByLeaseholderIdAsync(string leaseholderId)
        {
            return await _context.FavouritePosts
                .Where(pt => pt.LeaseholderId == leaseholderId )
                .Include(pt => pt.Post)
                .Include(pt => pt.Leaseholder)
                .ToListAsync();
        }

        public async Task<IEnumerable<FavouritePost>> ListByPostIdAsync(string postId)
        {
            return await _context.FavouritePosts
               .Where(pt => pt.PostId == postId)
               .Include(pt => pt.Post)
               .Include(pt => pt.Leaseholder)
               .ToListAsync();

        }

        public void Remove(FavouritePost favouritePost)
        {
            _context.FavouritePosts.Remove(favouritePost);
        }

        public async Task UnassignFavouritePostAsync(string postId, string leaseholderId)
        {
            FavouritePost favouritePost = await FindByPostIdAndLeaseholderId(postId, leaseholderId);
            if (favouritePost != null)
                Remove(favouritePost);
        }
    }
}
