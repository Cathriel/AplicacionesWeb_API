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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPlanRepository planRepository = null)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _planRepository = planRepository;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("Usuario inexistente");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Un error ocurrió al eliminar el usuario: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("Usuario inexistente");

            return new UserResponse(existingUser);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user,int planId)
        {

            var existingPlan = await _planRepository.FindById(planId);

            if (existingPlan == null)
                return new UserResponse("Plan inexistente");

            try
            {
                user.PlanId = planId;
                
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Un error ocurrió al guardar el usuario: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("Usuario inexistente");

            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.Province = user.Province;
            existingUser.District = user.District;
            existingUser.Address = user.Address;
            existingUser.Birthday = user.Birthday;
            existingUser.CellPhone = user.CellPhone;
            existingUser.Department = user.Department;
            existingUser.IdCard = user.IdCard;
            existingUser.Description = user.Description;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Un error ocurrió al actualizar el usuario: {ex.Message}");
            }
        }
    }
}
