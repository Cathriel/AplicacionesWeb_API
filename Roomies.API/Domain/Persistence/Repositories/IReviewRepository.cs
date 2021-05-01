using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByPostId(string postId);
        Task<IEnumerable<Review>> ListByLeaseholderId(string leaseholderId);
        Task<IEnumerable<Review>> ListByLandlordId(string landlordId);
        Task<Review> FindById(string id);

        Task AddAsync(Review review);
        void Remove(Review review);
        void Update(Review review);

    }
}
