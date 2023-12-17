using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Moq;
using ProiectMOPS.WEB.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProiectMOPS.Applications.Commands.ProductCommands;

namespace TestProjectMOPS
{
    [TestClass]
    public class UserControllerUnitTests
    {
        private readonly UserController _controller;
        private readonly LoginUserDTO _loginUserDto;
        private readonly User _user;
        private readonly string _role;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;

        public UserControllerUnitTests()
        {
            _userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<System.IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object
            );
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object
            );
            _controller = new UserController(_userManagerMock.Object, _roleManagerMock.Object);
            _user = new User
            {
                UserName = "Vlad"
                
            };
            _role = "Admin";
            _loginUserDto = new LoginUserDTO
            {
                UserName = "Vlad",
                Password = "Asdfg123*"
            };
        }

        [TestMethod]
        public async Task Login_ValidCredentials_ReturnsOkResult()
        {
            _userManagerMock.Setup(x => x.FindByNameAsync(_loginUserDto.UserName))
                .Returns(Task.FromResult(_user));
            _userManagerMock.Setup(x => x.CheckPasswordAsync(_user, _loginUserDto.Password))
                .Returns(Task.FromResult(true));
            _userManagerMock.Setup(x => x.GetRolesAsync(_user))
                .Returns(Task.FromResult<IList<string>>(new[] { "Admin" }));

            var result = await _controller.Login(_loginUserDto);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Login_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            _userManagerMock.Setup(x => x.FindByNameAsync(_loginUserDto.UserName))
                .Returns(Task.FromResult(_user));
            _userManagerMock.Setup(x => x.CheckPasswordAsync(_user, _loginUserDto.Password))
                .Returns(Task.FromResult(false));

            var result = await _controller.Login(_loginUserDto);

            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));           
        }

        [TestMethod]
        public async Task Register_ValidInput_ReturnsOkResult()
        {
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var result = await _controller.Register(new RegisterUserDTO { UserName = "Testuser", Password = "Password123!" });

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public async Task Register_InvalidInput_ReturnsBadRequestResult()
        {
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed()));

            var result = await _controller.Register(new RegisterUserDTO { UserName = "", Password = "" });

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task Register_UserExists_ReturnsConflictResult()
        {
            _userManagerMock.Setup(x => x.FindByNameAsync("Testuser"))
                .Returns(Task.FromResult(new User()));

            var result = await _controller.Register(new RegisterUserDTO { UserName = "Testuser", Password = "Password123!" });

            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
        }

        [TestMethod]
        public async Task AddToRole_ValidCredentials_ReturnsOkResult()
        {
            _userManagerMock.Setup(x => x.FindByNameAsync("Vlad"))
                .Returns(Task.FromResult(_user));
            _roleManagerMock.Setup(x => x.FindByNameAsync("Admin"))
                .Returns(Task.FromResult(It.IsAny<IdentityRole>()));
            _roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityRole>()))
                .Returns(Task.FromResult(It.IsAny<IdentityResult>()));
            _userManagerMock.Setup(x => x.AddToRoleAsync(_user, "Admin"))
                .Returns(Task.FromResult(It.IsAny<IdentityResult>()));

            var result = await _controller.AddToRole("Vlad", "Admin");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task ChangePassword_ValidCredentials_ReturnsOkResult()
        {
            _userManagerMock.Setup(x => x.FindByNameAsync("Vlad"))
                .Returns(Task.FromResult(_user));
            _userManagerMock.Setup(x => x.CheckPasswordAsync(_user, "Asdfg123*"))
                .Returns(Task.FromResult(true));
            _userManagerMock.Setup(x => x.ChangePasswordAsync(_user, "Asdfg123*", "Asdfg1234*"))
                .Returns(Task.FromResult(It.IsAny<IdentityResult>()));

            var result = await _controller.ChangePassword("Vlad", "Asdfg123*", "Asdfg1234*");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}