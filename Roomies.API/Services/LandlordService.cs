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
    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _landlordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LandlordService(ILandlordRepository landlordRepository, IUnitOfWork unitOfWork)
        {
            _landlordRepository = landlordRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LandlordResponse> DeleteAsync(string id)
        {
            var existingLandlord = await _landlordRepository.FindById(id);

            if (existingLandlord == null)
                return new LandlordResponse("Arrendador inexistente");

            try
            {
                _landlordRepository.Remove(existingLandlord);
                await _unitOfWork.CompleteAsync();

                return new LandlordResponse(existingLandlord);
            }
            catch (Exception ex)
            {
                return new LandlordResponse($"Un error ocurrió al eliminar el arrendador: {ex.Message}");
            }
        }

        public async Task<LandlordResponse> GetByIdAsync(string id)
        {
            var existingLandlord = await _landlordRepository.FindById(id);

            if (existingLandlord == null)
                return new LandlordResponse("Arrendador inexistente");

            return new LandlordResponse(existingLandlord);
        }

        public async Task<IEnumerable<Landlord>> ListAsync()
        {
            return await _landlordRepository.ListAsync();
        }

        public async Task<LandlordResponse> SaveAsync(Landlord landlord)
        {
            try
            {
                await _landlordRepository.AddAsync(landlord);
                await _unitOfWork.CompleteAsync();

                return new LandlordResponse(landlord);
            }
            catch (Exception ex)
            {
                return new LandlordResponse($"Un error ocurrió al guardar el arrendador: {ex.Message}");
            }
        }

        public async Task<LandlordResponse> UpdateAsync(string id, Landlord landlord)
        {
            var existingLandlord = await _landlordRepository.FindById(id);

            if (existingLandlord == null)
                return new LandlordResponse("Arrendador inexistente");

            //existingLandlord.Name = landlord.Name;
            //existingLandlord.Address = landlord.Address;
            //existingLandlord.Birthday = landlord.Birthday;
            //existingLandlord.Email = landlord.Email;
            //existingLandlord.Department = landlord.Department;
            //existingLandlord.CellPhone = landlord.CellPhone;
            //existingLandlord.District = landlord.District;
            //existingLandlord.LastName = landlord.LastName;
            existingLandlord = landlord;

            try
            {
                _landlordRepository.Update(existingLandlord);
                await _unitOfWork.CompleteAsync();

                return new LandlordResponse(existingLandlord);
            }
            catch (Exception ex)
            {
                return new LandlordResponse($"Un error ocurrió al actualizar el arrendador: {ex.Message}");
            }
        }
    }
}
