using NUnit.Framework;
using Moq;
using FluentAssertions;
using Roomies.API.Domain.Repositories;
using Roomies.API.Services;
using Roomies.API.Domain.Services.Communications;
using System.Threading.Tasks;
using System.Collections.Generic;
using Roomies.API.Domain.Models;
using Roomies.API.Domain.Persistence.Repositories;
using System;

namespace Roomies.API.Test
{
    public class LeaseholderServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task SaveLeaseholderWhenParametersAreTheSameReturnsCantSave()
        {
            // Arrange

            var mockLeaseholderRepository = GetDefaultILeaseholderRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockFavouritePostRepository = GetDefaultFavouritePostRepositoryInstance();
            var mockPlanRepository = GetDefaultIPlanRepositoryInstance();

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            string email = "email";

            Plan plan = new Plan
            {
                Id=1

            };

            Leaseholder leaseholder1 = new Leaseholder
            {
                IdUser = 1,
                Email=email

            };

            Leaseholder leaseholder2 = new Leaseholder
            {
                IdUser = 2,
                Email = email

            };

            List<User> users = new List<User>();
            //:(
            users.Add(leaseholder1);
           
            mockPlanRepository.Setup(u => u.AddAsync(plan)).Returns(Task.FromResult<Plan>(plan));
            mockPlanRepository.Setup(u => u.FindById(1)).Returns(Task.FromResult<Plan>(plan));
            
            mockUserRepository.Setup(u => u.ListAsync()).Returns(Task.FromResult<IEnumerable<User>>(users as IEnumerable<User>));

            mockLeaseholderRepository.Setup(u => u.FindById(1)).Returns(Task.FromResult<Leaseholder>(leaseholder1));
            mockLeaseholderRepository.Setup(u => u.AddAsync(leaseholder2)).Returns(Task.FromResult<Leaseholder>(null));

            var service = new LeaseholderService(mockLeaseholderRepository.Object,mockFavouritePostRepository.Object,mockUnitOfWork.Object,mockPlanRepository.Object,mockUserRepository.Object);



            // Act


            LeaseholderResponse result = await service.SaveAsync(leaseholder2,1);
            var message = result.Message;


            // Assert

           message.Should().Be("El email ingresado ya existe");
        }


        [Test]
        public async Task SaveLeaseholderWhenParametersAreDifferentCanSave()
        {
            // Arrange

            var mockLeaseholderRepository = GetDefaultILeaseholderRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockFavouritePostRepository = GetDefaultFavouritePostRepositoryInstance();
            var mockPlanRepository = GetDefaultIPlanRepositoryInstance();

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            string email = "email";

            Plan plan = new Plan
            {
                Id = 1

            };

            Leaseholder leaseholder1 = new Leaseholder
            {
                IdUser = 1,
                Email = email

            };

            Leaseholder leaseholder2 = new Leaseholder
            {
                IdUser = 2,
                Email = "email2"

            };

            List<User> users = new List<User>();
            //:(
            users.Add(leaseholder1);

            mockPlanRepository.Setup(u => u.AddAsync(plan)).Returns(Task.FromResult<Plan>(plan));
            mockPlanRepository.Setup(u => u.FindById(1)).Returns(Task.FromResult<Plan>(plan));

            mockUserRepository.Setup(u => u.ListAsync()).Returns(Task.FromResult<IEnumerable<User>>(users as IEnumerable<User>));

            mockLeaseholderRepository.Setup(u => u.FindById(1)).Returns(Task.FromResult<Leaseholder>(leaseholder1));
            mockLeaseholderRepository.Setup(u => u.AddAsync(leaseholder2)).Returns(Task.FromResult<Leaseholder>(null));

            var service = new LeaseholderService(mockLeaseholderRepository.Object, mockFavouritePostRepository.Object, mockUnitOfWork.Object, mockPlanRepository.Object, mockUserRepository.Object);



            // Act


            LeaseholderResponse result = await service.SaveAsync(leaseholder2, 1);
            


            // Assert

            result.Resource.Should().Be(leaseholder2);
        }


        private Mock<ILeaseholderRepository> GetDefaultILeaseholderRepositoryInstance()
        {
            return new Mock<ILeaseholderRepository>();
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IPlanRepository> GetDefaultIPlanRepositoryInstance()
        {
            return new Mock<IPlanRepository>();
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