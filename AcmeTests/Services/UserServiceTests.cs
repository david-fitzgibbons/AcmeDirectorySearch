namespace AcmeTests.Services
{
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Models;
    using AcmeDirectorySearch.Core.Services;
    using AcmeDirectorySearch.Infrastructure.Interfaces;
    using AutoMapper;
    using Moq;
    using System;
    using Xunit;

    public class UserServiceTests
    {

        [Fact]
        public async void Check_User_Validation_On_Create()
        {
            var mockrepo = new Mock<IUserRepository>();
            mockrepo.Setup(repo => repo.CreateUser(It.IsAny<User>(), It.IsAny<UserImageDTO>()))
                .ReturnsAsync(HelperData.User());

            //Change the FirstName to an INVALID state on the Mapper Response
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserDTO, User>(It.IsAny<UserDTO>()))
                .Returns(HelperData.User(FirstName: ""));

            mapperMock.Setup(m => m.Map<User, UserDTO>(It.IsAny<User>()))
                .Returns(HelperData.UserDTO());

            var usersrv = new UserService(mockrepo.Object, mapperMock.Object);

            //Checks model validation before creation
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await usersrv.CreateUser(HelperData.UserDTO()));
        }


        [Fact]
        public async void Check_Address_Validation_On_Create()
        {
            var mockrepo = new Mock<IUserRepository>();
            mockrepo.Setup(repo => repo.CreateUser(It.IsAny<User>(), It.IsAny<UserImageDTO>()))
                .ReturnsAsync(HelperData.User());

            //Change the FirstName to an INVALID state on the Mapper Response
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserDTO, User>(It.IsAny<UserDTO>()))
                .Returns(HelperData.User(City: ""));

            mapperMock.Setup(m => m.Map<User, UserDTO>(It.IsAny<User>()))
                .Returns(HelperData.UserDTO());

            var usersrv = new UserService(mockrepo.Object, mapperMock.Object);

            //Checks model validation before creation
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await usersrv.CreateUser(HelperData.UserDTO()));
        }
    }
}
