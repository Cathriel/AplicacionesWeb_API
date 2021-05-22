using Roomies.API.Domain.Models;
using Roomies.API.Domain.Persistence.Repositories;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ConversationService(IUnitOfWork unitOfWork, IConversationRepository conversationRepository, IUserRepository userRepository = null)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public async Task<ConversationResponse> DeleteAsync(int id)
        {
            var existingConversation = await _conversationRepository.FindById(id);

            if (existingConversation == null)
                return new ConversationResponse("Conversación inexistente");

            try
            {
                _conversationRepository.Remove(existingConversation);
                await _unitOfWork.CompleteAsync();

                return new ConversationResponse(existingConversation);
            }
            catch (Exception ex)
            {
                return new ConversationResponse($"Un error ocurrió al buscar la conversación: {ex.Message}");
            }
        }

        public async Task<ConversationResponse> GetByIdAsync(int id)
        {
            var existingConversation = await _conversationRepository.FindById(id);

            if (existingConversation == null)
                return new ConversationResponse("Conversación inexistente");

            return new ConversationResponse(existingConversation);
        }


        public async Task<IEnumerable<Conversation>> ListAsync()
        {
            return await _conversationRepository.ListAsync();
        }

        public async Task<ConversationResponse> SaveAsync(Conversation conversation)
        {
            try
            {
                await _conversationRepository.AddAsync(conversation);
                await _unitOfWork.CompleteAsync();

                return new ConversationResponse(conversation);
            }
            catch (Exception ex)
            {
                return new ConversationResponse($"Un error ocurrió al guardar la conversación: {ex.Message}");
            }
        }

    }
}
