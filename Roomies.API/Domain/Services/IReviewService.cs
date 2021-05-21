using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByLeaseholderIdAsync(string leaseholderId);
        Task<ReviewResponse> GetByIdAsync(string reviewId);
        Task<ReviewResponse> SaveAsync(Review review);
        Task<ReviewResponse> UpdateAsync(string id, Review review);
        Task<ReviewResponse> DeleteAsync(string id);
    }
}
