using NUnit.Framework;
using Moq;
using UserDataAccess.Interfaces;
using System.Collections.Generic;
using UserDataAccess.Entities;
using System.Linq;
using MockQueryable.Moq;
using UserBL.Managers;
using UserBL.ViewModels;
using AutoMapper;
using Profiles;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserTest
{
    public class UserManagerTests
    {
        private Mock<IDBContext> _contextMock;
        private Mock<DbSet<User>> _usersMock;

        private const string _lastName = "ExistLastName";

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IDBContext>();
            var users = new List<User>()
            {
                new User{LastName = _lastName},
            };

            _usersMock = users.AsQueryable().BuildMockDbSet();
            _contextMock.Setup(x => x.Users).Returns(_usersMock.Object);
        }

        private IMapper GetMapper()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return mappingConfig.CreateMapper();
        }

        [Test]
        public async Task GetAllAsyncTest()
        {
            var userManager = new UserManager(_contextMock.Object, GetMapper());
            var result = await userManager.GetAllAsync();

            Assert.IsTrue(result.Count() == 1, "Amount of users is not correct");
            Assert.IsTrue(result.First().LastName == _lastName, "User's last name is not correct");
        }

        [Test]
        public async Task AddUserAsyncTest()
        {
            var userManager = new UserManager(_contextMock.Object, GetMapper());

            var newUserName = "TestUser";
            var result = await userManager.AddUserAsync(new UserVM
            {
                LastName = newUserName,
            });

            var result2 = await userManager.GetAllAsync();
            
            _usersMock.Verify(mock => mock.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once());
            _contextMock.Verify(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

            Assert.IsTrue(result.LastName == newUserName, "User's last name is not correct");
        }
    }
}