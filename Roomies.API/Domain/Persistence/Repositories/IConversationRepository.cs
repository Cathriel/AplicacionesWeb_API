using Roomies.API.Domain.Models;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Repositories
{
    public interface IConversationRepository
    {
        Task<IEnumerable<Conversation>> ListAsync();
        Task<Conversation> FindById(string id);
        Task AddAsync(Conversation conversation);
        void Update(Conversation conversation);
        void Remove(Conversation conversation);

    }
}
