using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<IEnumerable<Post>> ListByLandlordIdAsync(string landlordId);
        Task<PostResponse> GetByIdAsync(string postId);
        Task<PostResponse> SaveAsync(Post post);
        Task<PostResponse> UpdateAsync(string id, Post post);
        Task<PostResponse> DeleteAsync(string id);
    }
}
