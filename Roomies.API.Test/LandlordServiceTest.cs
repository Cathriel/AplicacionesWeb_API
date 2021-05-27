//using NUnit.Framework;
//using Moq;
//using FluentAssertions;
//using Roomies.API.Domain.Repositories;
//using Roomies.API.Services;
//using Roomies.API.Domain.Services.Communications;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using Roomies.API.Domain.Models;

//namespace Roomies.API.Test
//{
//    public class LandlordServiceTest
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public async Task GetAllAsyncWhenNoLandlordReturnsEmptyCollection()
//        {
//            // Arrange

//            var mockLandlordRepository = GetDefaultILandlordRepositoryInstance();
//            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

//            mockLandlordRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Landlord>());

//            var service = new LandlordService(mockLandlordRepository.Object, mockUnitOfWork.Object);

//            // Act

//            List<Landlord> result = (List<Landlord>)await service.ListAsync();
//            var landlordCount = result.Count;

//            // Assert

//            landlordCount.Should().Equals(0);
//        }

//        [Test]
//        public async Task GetByIdAsyncWhenInvalidIdReturnsLandlordNotFoundResponse()
//        {
//            // Arrange
//            var mockLandlordRepository = GetDefaultILandlordRepositoryInstance();
//            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
//            var landlordId = "1";
//            Landlord landlord = new Landlord();
//            mockLandlordRepository.Setup(r => r.FindById(landlordId)).Returns(Task.FromResult<Landlord>(null));
//            var service = new LandlordService( mockLandlordRepository.Object, mockUnitOfWork.Object);

//            // Act
//            LandlordResponse result = await service.GetByIdAsync(landlordId);
//            var message = result.Message;

//            // Assert
//            message.Should().Be("Arrendador inexistente");
//        }

//        private Mock<ILandlordRepository> GetDefaultILandlordRepositoryInstance()
//        {
//            return new Mock<ILandlordRepository>();
//        }

//        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
//        {
//            return new Mock<IUnitOfWork>();
//        }
//    }
//}