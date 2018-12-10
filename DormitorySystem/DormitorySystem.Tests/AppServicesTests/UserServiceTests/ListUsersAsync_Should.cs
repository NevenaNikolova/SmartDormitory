using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.AppServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.AppServicesTests.UserServiceTests
{
    [TestClass]
    public class ListUsersAsync_Should
    {
        [TestMethod]
        public async Task ReturnListOfUsers_WhenCollectionIsNotEmpty()
        {
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnListOfUsers_WhenCollectionIsNotEmpty")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            var user = new User
            {
                Id= "00000000-0000-0000-0000-000000000001",
                Email="new@user.com"
            };

            //Act
            using (var actContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                actContext.Users.Add(user);
                actContext.SaveChanges();
            }
            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new UserService(assertContext);
                var result = await service.ListUsersAsync();

                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(user.Id, result.First().Id);
            }
        }
        [TestMethod]
        public async Task ReturnEmptyCollection_WhenNoUsers()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnEmptyCollection_WhenNoUsers")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new UserService(assertContext);
                var result = await service.ListUsersAsync();

                Assert.AreEqual(0, result.Count());
            }
        }
    }
}
