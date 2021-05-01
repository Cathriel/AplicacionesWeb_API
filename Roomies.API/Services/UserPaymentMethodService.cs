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
    public class UserPaymentMethodService : IUserPaymentMethodService
    {
        private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserPaymentMethodService(IUserPaymentMethodRepository userPaymentMethodRepository, IUnitOfWork unitOfWork)
        {
            _userPaymentMethodRepository = userPaymentMethodRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<UserPaymentMethodResponse> AssignUserPaymentMethodAsync(string userId, string paymentMethodId)
        {
            try
            {
                await _userPaymentMethodRepository.AssignUserPaymentMethodAsync(userId, paymentMethodId);
                await _unitOfWork.CompleteAsync();
                UserPaymentMethod userPaymentMethod = await _userPaymentMethodRepository.FindByUserIdAndPaymentMethodId(userId, paymentMethodId);
                return new UserPaymentMethodResponse(userPaymentMethod);

            }
            catch (Exception ex)
            {
                return new UserPaymentMethodResponse($"Un error ocurrió al asignar usuario y método de pago: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListAsync()
        {
            return await _userPaymentMethodRepository.ListAsync();
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(string paymentMethodId)
        {
            return await _userPaymentMethodRepository.ListByPaymentMethodIdAsync(paymentMethodId);
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(string userId)
        {
            return await _userPaymentMethodRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserPaymentMethodResponse> UnassignUserPaymentMethodAsync(string userId, string paymentMethodId)
        {
            try
            {
                UserPaymentMethod userPaymentMethod = await _userPaymentMethodRepository.FindByUserIdAndPaymentMethodId(userId, paymentMethodId);

                _userPaymentMethodRepository.Remove(userPaymentMethod);
                await _unitOfWork.CompleteAsync();

                return new UserPaymentMethodResponse(userPaymentMethod);

            }
            catch (Exception ex)
            {
                return new UserPaymentMethodResponse($"Un error ocurrió al desasignar usuario y método de pago: {ex.Message}");
            }
        }
    }
}
