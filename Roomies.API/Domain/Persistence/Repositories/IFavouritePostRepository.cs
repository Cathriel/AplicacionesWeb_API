using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface IFavouritePostRepository
    {
        Task<IEnumerable<FavouritePost>> ListAsync();
        Task<IEnumerable<FavouritePost>> ListByPostIdAsync(string postId);
        Task<IEnumerable<FavouritePost>> ListByLeaseholderIdAsync(string leaseholderId);
        Task<FavouritePost> FindByPostIdAndLeaseholderId(string postId,string leaseholderId);
        Task AddAsync(FavouritePost favouritePost);
        void Remove(FavouritePost favouritePost);
        Task AssignFavouritePostAsync(string postId, string leaseholderId);
        Task UnassignFavouritePostAsync(string postId, string leaseholderId);

    }
}
