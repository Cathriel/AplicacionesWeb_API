using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IUserPaymentMethodService
    {
        Task<IEnumerable<UserPaymentMethod>> ListAsync();
        Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(string paymentMethodId);
        Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(string userId);
        Task<UserPaymentMethodResponse> AssignUserPaymentMethodAsync(string userId, string paymentMethodId);
        Task<UserPaymentMethodResponse> UnassignUserPaymentMethodAsync(string userId, string paymentMethodId);
    }
}
