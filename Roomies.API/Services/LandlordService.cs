using Roomies.API.Domain.Models;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Services
{
    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _landlordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LandlordService(ILandlordRepository landlordRepository, IUnitOfWork unitOfWork)
        {
            _landlordRepository = landlordRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Landlord>> ListAsync()
        {
            return await _landlordRepository.ListAsync();
        }
    }
}
