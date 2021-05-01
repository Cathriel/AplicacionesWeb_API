using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IFavouritePostService
    {
        Task<IEnumerable<FavouritePost>> ListAsync();
        Task<IEnumerable<FavouritePost>> ListByPostIdAsync(string postId);
        Task<IEnumerable<FavouritePost>> ListByLeaseholderIdAsync(string leaseholderId);
        Task<FavouritePostResponse> AssignFavouritePostAsync(string postId, string leaseholderId);
        Task<FavouritePostResponse> UnassignFavouritePostAsync(string postId, string leaseholderId);
    }
}
