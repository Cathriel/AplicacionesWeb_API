using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface IUserPaymentMethodRepository
    {
        Task<IEnumerable<UserPaymentMethod>> ListAsync();
        Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(string paymentMethodId);
        Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(string userId);
        void Remove(UserPaymentMethod userPaymentMethod);
        Task AddAsync(UserPaymentMethod userPaymentMethod);
        Task<UserPaymentMethod> FindByUserIdAndPaymentMethodId(string userId, string paymentMethodId);
        Task AssignUserPaymentMethodAsync(string userId, string paymentMethodId);
        Task UnassignUserPaymentMethodAsync(string userId, string paymentMethodId);

    }
}
