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
    public class LeaseholderService : ILeaseholderService
    {
        private readonly ILeaseholderRepository _leaseholderRepository;
        private readonly IFavouritePostRepository _favouritePostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LeaseholderService(ILeaseholderRepository leaseholderRepository, IFavouritePostRepository favouritePostRepository, IUnitOfWork unitOfWork)
        {
            _leaseholderRepository = leaseholderRepository;
            _favouritePostRepository = favouritePostRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LeaseholderResponse> DeleteAsync(string id)
        {
            var existingLeaseholder = await _leaseholderRepository.FindById(id);

            if (existingLeaseholder == null)
                return new LeaseholderResponse("Arrendatario inexistente");

            try
            {
                _leaseholderRepository.Remove(existingLeaseholder);
                await _unitOfWork.CompleteAsync();

                return new LeaseholderResponse(existingLeaseholder);
            }
            catch (Exception ex)
            {
                return new LeaseholderResponse($"Un error ocurrió al eliminar el Arrendatario: {ex.Message}");
            }
        }

        public async Task<LeaseholderResponse> GetByIdAsync(string id)
        {
            var existingLeaseholder = await _leaseholderRepository.FindById(id);

            if (existingLeaseholder == null)
                return new LeaseholderResponse("Arrendatario inexistente");

            return new LeaseholderResponse(existingLeaseholder);
        }

        public async Task<IEnumerable<Leaseholder>> ListAsync()
        {
            return await _leaseholderRepository.ListAsync();
        }

        public async Task<IEnumerable<Leaseholder>> ListByPostIdAsync(string postId)
        {
            var favouritePost = await _favouritePostRepository.ListByPostIdAsync(postId);
            var leaseholders= favouritePost.Select(pt => pt.Leaseholder).ToList();
            return leaseholders;
        }

        public async Task<LeaseholderResponse> SaveAsync(Leaseholder leaseholder)
        {
            try
            {
                await _leaseholderRepository.AddAsync(leaseholder);
                await _unitOfWork.CompleteAsync();

                return new LeaseholderResponse(leaseholder);
            }
            catch (Exception ex)
            {
                return new LeaseholderResponse($"Un error ocurrió al guardar el arrendatario: {ex.Message}");
            }
        }

        public async Task<LeaseholderResponse> UpdateAsync(string id, Leaseholder leaseholder)
        {
            var existingLeaseholder= await _leaseholderRepository.FindById(id);

            if (existingLeaseholder == null)
                return new LeaseholderResponse("Arrendatario inexistente");

            existingLeaseholder = leaseholder;

            try
            {
                _leaseholderRepository.Update(existingLeaseholder);
                await _unitOfWork.CompleteAsync();

                return new LeaseholderResponse(existingLeaseholder);
            }
            catch (Exception ex)
            {
                return new LeaseholderResponse($"Un error ocurrió al actualizar el arrendador: {ex.Message}");
            }
        }
    }
}
