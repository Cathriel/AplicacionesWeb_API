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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IFavouritePostRepository _favouritePostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, IFavouritePostRepository favouritePostRepository)
        {
            _postRepository = postRepository;
            _favouritePostRepository = favouritePostRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<PostResponse> DeleteAsync(string id)
        {
            var existingPost = await _postRepository.FindById(id);

            if (existingPost == null)
                return new PostResponse("Post inexistente");

            try
            {
                _postRepository.Remove(existingPost);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"Un error ocurrió al buscar el post: {ex.Message}");
            }
        }

        public async Task<PostResponse> GetByIdAsync(string postId)
        {
            var existingPost= await _postRepository.FindById(postId);

            if (existingPost == null)
                return new PostResponse("Post inexistente");

            return new PostResponse(existingPost);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<IEnumerable<Post>> ListByLandlordIdAsync(string landlordId)
        {
            return await _postRepository.ListByLandlordIdAsync(landlordId);
        }


        public async Task<PostResponse> SaveAsync(Post post)
        {
            try
            {
                await _postRepository.AddAsync(post);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception ex)
            {
                return new PostResponse($"Un error ocurrió al guardar el post: {ex.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(string id, Post post)
        {
            var existingPost = await _postRepository.FindById(id);

            if (existingPost == null)
                return new PostResponse("Post inexistente");

            existingPost.Title = post.Title;

            try
            {
                _postRepository.Update(existingPost);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"Un error ocurrió al actualizar el post: {ex.Message}");
            }
        }
    }
}
