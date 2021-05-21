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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(string id)
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

        public async Task<UserResponse> GetByIdAsync(string id)
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

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Un error ocurrió al guardar el usuario: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(string id, User user)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("Usuario inexistente");

            existingUser.Name = user.Name;

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
