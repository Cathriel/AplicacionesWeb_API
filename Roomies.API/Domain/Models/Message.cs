using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Message
    {
        public string Id { set; get; }
        public string Content { set; get; } 
        public DateTime SentDate { set; get; }
        public bool Seen { set; get; }
        public string ConversationId { set; get; }
        public Conversation Conversation { set; get; }
    }
}
