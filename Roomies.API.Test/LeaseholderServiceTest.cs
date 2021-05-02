using NUnit.Framework;
using Moq;
using FluentAssertions;
using Roomies.API.Domain.Repositories;
using Roomies.API.Services;
using Roomies.API.Domain.Services.Communications;
using System.Threading.Tasks;
using System.Collections.Generic;
using Roomies.API.Domain.Models;

namespace Roomies.API.Test
{
    public class LeaseholderServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoLeaseholderReturnsEmptyCollection()
        {
            // Arrange

            var mockLeaseholderRepository = GetDefaultILeaseholderRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFavouritePostRepository = GetDefaultFavouritePostRepositoryInstance();

            mockLeaseholderRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Leaseholder>());

            var service = new LeaseholderService(mockLeaseholderRepository.Object, mockFavouritePostRepository.Object,mockUnitOfWork.Object);

            // Act

            List<Leaseholder> result = (List<Leaseholder>)await service.ListAsync();
            var leaseholderCount = result.Count;

            // Assert

            leaseholderCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsLeaseholderNotFoundResponse()
        {
            // Arrange
            var mockLeaseholderRepository = GetDefaultILeaseholderRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFavouritePostRepository = GetDefaultFavouritePostRepositoryInstance();

            var leaseholderId = "1";
            Leaseholder leaseholder = new Leaseholder();
            mockLeaseholderRepository.Setup(r => r.FindById(leaseholderId)).Returns(Task.FromResult<Leaseholder>(null));
            var service = new LeaseholderService(mockLeaseholderRepository.Object, mockFavouritePostRepository.Object, mockUnitOfWork.Object);

            // Act
            LeaseholderResponse result = await service.GetByIdAsync(leaseholderId);
            var message = result.Message;

            // Assert
            message.Should().Be("Arrendatario inexistente");
        }

        private Mock<ILeaseholderRepository> GetDefaultILeaseholderRepositoryInstance()
        {
            return new Mock<ILeaseholderRepository>();
        }

        private Mock<IFavouritePostRepository> GetDefaultFavouritePostRepositoryInstance()
        {
            return new Mock<IFavouritePostRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}