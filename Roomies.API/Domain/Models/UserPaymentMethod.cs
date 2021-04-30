using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class UserPaymentMethod
    {
        public string UserId { get; set; }
        public string PaymentMethodId { get; set; }
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
