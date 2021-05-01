using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Resources
{
    public class ConversationResource
    {
        public string Id { set; get; }
        public UserResource SenderResource { set; get; }
        public UserResource ReceiverResource { set; get; }

        public DateTime DateCreation { set; get; }
    }
}
