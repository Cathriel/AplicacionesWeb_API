using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Resources
{
    public class ConversationResource
    {
        public string Id { set; get; }
        public UserResource User1Resource { set; get; }
       // public UserResource User2Resource { set; get; }

        public DateTime DateCreation { set; get; }
    }
}
