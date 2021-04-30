using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class PaymentMethod
    {
        public string Id { get; set; }
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<UserPaymentMethod> UserPaymentMethods { get; set; }
    }
}
