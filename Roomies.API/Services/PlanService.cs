using Roomies.API.Domain.Models;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using Roomies.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingPlan= await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan inexistente");

            try
            {
                _planRepository.Remove(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"Un error ocurrió al buscar el plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> GetByIdAsync(int id)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan inexistente");

            return new PlanResponse(existingPlan);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.AddAsync(plan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(plan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"Un error ocurrió al guardar el plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan inexistente");

            existingPlan.Name = plan.Name;
            existingPlan.Description = plan.Description;
            existingPlan.Price = plan.Price;

            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"Un error ocurrió al actualizar el plan: {ex.Message}");
            }
        }
    }
}
