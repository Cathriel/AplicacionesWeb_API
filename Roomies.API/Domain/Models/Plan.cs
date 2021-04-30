using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Plan
    {
        public string Id { set; get; }
        public float Price { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public DateTime StartSubscription { set; get; }
        public DateTime EndSubsciption { set; get; }
        public List<User> Users { set; get; }
    }
}
