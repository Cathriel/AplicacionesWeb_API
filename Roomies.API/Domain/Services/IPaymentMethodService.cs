using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> ListAsync();
        Task<IEnumerable<PaymentMethod>> ListByUserIdAsync(string userId);
        Task<PaymentMethodResponse> GetByIdAsync(string id);
        Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod);
        Task<PaymentMethodResponse> DeleteAsync(string id);
    }
}
