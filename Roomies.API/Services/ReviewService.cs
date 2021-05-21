using Roomies.API.Domain.Models;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<ReviewResponse> DeleteAsync(string id)
        {
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Reseña inexistente");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"Un error ocurrió al buscar la reseña: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> GetByIdAsync(string reviewId)
        {
            var existingReview = await _reviewRepository.FindById(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review inexistente");

            return new ReviewResponse(existingReview);
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _reviewRepository.ListAsync();
        }


        public async Task<IEnumerable<Review>> ListByLeaseholderIdAsync(string leaseholderId)
        {
            return await _reviewRepository.ListByLeaseholderId(leaseholderId);
        }

        public async Task<ReviewResponse> SaveAsync(Review review)
        {
            try
            {
                await _reviewRepository.AddAsync(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"Un error ocurrió al guardar la reseña: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> UpdateAsync(string id, Review review)
        {
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Review inexistente");


            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"Un error ocurrió al actualizar la reseña: {ex.Message}");
            }
        }
    }
}
