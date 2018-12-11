using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.AppServices;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.AppServicesTests.UserServiceTests
{
    [TestClass]
    public class DeleteUserAsync_Should
    {
        [TestMethod]
        public async Task SetUserIsDeleted_ToTrue()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("SetUserIsDeleted_ToTrue")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            var user = new User
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com"
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
                var result = await service.DeleteUserAsync(user.Id);

                StringAssert.Contains("True", result.isDeleted.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserNullableException))]
        public async Task ThrowUserNullableException_WhenInvalidIdIsPassed()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ThrowUserNullableException_WhenInvalidIdIsPassed")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new UserService(assertContext);
                var userId = "10";
                var result = await service.DeleteUserAsync(userId);
            }
        }
    }
}
