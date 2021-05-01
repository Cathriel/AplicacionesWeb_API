﻿using Roomies.API.Domain.Models;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse> DeleteAsync(string id)
        {
            var existingMessage = await _messageRepository.FindById(id);

            if (existingMessage == null)
                return new MessageResponse("Mensaje inexistente");

            try
            {
                _messageRepository.Remove(existingMessage);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(existingMessage);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"Un error ocurrió al buscar el mensaje: {ex.Message}");
            }
        }

        public async Task<MessageResponse> GetByIdAsync(string id)
        {
            var existingMessage = await _messageRepository.FindById(id);

            if (existingMessage == null)
                return new MessageResponse("Mensaje inexistente");

            return new MessageResponse(existingMessage);
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }

        public async Task<IEnumerable<Message>> ListByConversationIdAsync(string conversationId)
        {
            return await _messageRepository.ListByConversationIdAsync(conversationId);
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            try
            {
                await _messageRepository.AddAsync(message);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(message);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"Un error ocurrió al guardar el mensaje: {ex.Message}");
            }
        }
    }
}
