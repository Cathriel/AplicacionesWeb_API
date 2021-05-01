using Roomies.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListByConversationIdAsync(string conversationId);
        Task<Message> FindById(string id);
        Task AddAsync(Message message);
        void Update(Message message);
        void Remove(Message message);
    }
}
