using Roomies.API.Domain.Models;
using Roomies.API.Domain.Persistence.Repositories;
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
        private readonly IPlanRepository _planRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public LandlordService(ILandlordRepository landlordRepository, IUnitOfWork unitOfWork, IPlanRepository planRepository = null, IPostRepository postRepository = null, IUserRepository userRepository = null)
        {
            _landlordRepository = landlordRepository;
            _unitOfWork = unitOfWork;
            _planRepository = planRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<LandlordResponse> DeleteAsync(int id)
        {
            var existingLandlord = await _landlordRepository.FindById(id);

            if (existingLandlord == null)
                return new LandlordResponse("Arrendador inexistente");

           
            try
            {
                if (existingLandlord.Posts != null)
                {
                    existingLandlord.Posts.ForEach(delegate (Post post)
                {
                    _postRepository.Remove(post);
                });
                }

                _landlordRepository.Remove(existingLandlord);
                await _unitOfWork.CompleteAsync();

                return new LandlordResponse(existingLandlord);
            }
            catch (Exception ex)
            {
                return new LandlordResponse($"Un error ocurrió al eliminar el arrendador: {ex.Message}");
            }
        }

        public async Task<LandlordResponse> GetByIdAsync(int id)
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

        public async Task<LandlordResponse> SaveAsync(Landlord landlord,int planId)
        {
            var existingPlan = await _planRepository.FindById(planId);

            if (existingPlan == null)
                return new LandlordResponse("Plan inexistente");

            DateTime fechaActual = DateTime.Today;
            if (fechaActual.Year - landlord.Birthday.Year < 18)
            {
                return new LandlordResponse("El Landlord debe ser mayor de 18 años");
            }

            try
            {
                IEnumerable<User> users = await _userRepository.ListAsync();

                bool different = true;

                if (users != null)
                    users.ToList().ForEach(user =>
                    {
                        if (landlord.Email == user.Email)
                            different = false;
                    });

                if (different == false)
                    return new LandlordResponse("El email ingresado ya existe");

                landlord.PlanId = planId;

                await _landlordRepository.AddAsync(landlord);
                await _unitOfWork.CompleteAsync();

                return new LandlordResponse(landlord);
            }
            catch (Exception ex)
            {
                return new LandlordResponse($"Un error ocurrió al guardar el arrendador: {ex.Message}");
            }
        }

        public async Task<LandlordResponse> UpdateAsync(int id, Landlord landlord)
        {
            var existingLandlord = await _landlordRepository.FindById(id);

            if (existingLandlord == null)
                return new LandlordResponse("Arrendador inexistente");

            existingLandlord.Name = landlord.Name;
            existingLandlord.Address = landlord.Address;
            existingLandlord.Birthday = landlord.Birthday;
            existingLandlord.Email = landlord.Email;
            existingLandlord.Department = landlord.Department;
            existingLandlord.CellPhone = landlord.CellPhone;
            existingLandlord.District = landlord.District;
            existingLandlord.LastName = landlord.LastName;
            existingLandlord.Province = landlord.Province;
            existingLandlord.IdCard = landlord.IdCard;
            existingLandlord.Password = landlord.Password;

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
