using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Conversation
    {
        public string Id { set; get; }
        public User Sender { set; get; }
        public User Receiver { set; get; }
        public DateTime DateCreation { set; get; }
    }
}
