using NUnit.Framework;
using Moq;
using UserDataAccess.Interfaces;
using System.Collections.Generic;
using UserDataAccess.Entities;
using System.Linq;
using MockQueryable.Moq;
using UserBL.Managers;
using AutoMapper;
using Profiles;
using System.Threading.Tasks;

namespace UserTest
{
    public class UserManagerTests
    {
        private Mock<IDBContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IDBContext>();
            var users = new List<User>()
            {
                new User{LastName = "ExistLastName"},
            };

            var mock = users.AsQueryable().BuildMockDbSet();
            _contextMock.Setup(x => x.Users).Returns(mock.Object);
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

            Assert.Pass();
        }
    }
}