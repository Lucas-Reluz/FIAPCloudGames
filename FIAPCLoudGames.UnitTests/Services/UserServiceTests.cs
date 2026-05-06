using FIAPCloudGames.Application.Services;
using FIAPCloudGames.Domain.Exceptions;
using FIAPCLoudGames.UnitTests.Fakes;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCLoudGames.UnitTests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public void Create_Valid_User()
        {
            var repo = new FakeUserRepository();
            var service = new UserService(repo);

            service.Register("Lucas Reluz", "lucas77@email.com", "123@abcD", false);

            Assert.Single(repo.Users);
        }

        [Fact]
        public void Not_Create_User_Email_Already_Exists()
        {
            var repo = new FakeUserRepository();
            var service = new UserService(repo);

            service.Register("Lucas Reluz", "lucas77@email.com", "123@abcD", false);

            Assert.Throws<BusinessException>(() =>
                service.Register("Lucas Reluz", "lucas77@email.com", "123@abcD", false));
        }

        [Fact]
        public void Throw_Error_When_Password_Is_Weak()
        {
            var repo = new FakeUserRepository();
            var service = new UserService(repo);

            Assert.Throws<DomainException>(() =>
                service.Register("Lucas", "lucas@email.com", "123", false));
        }

        [Fact]
        public void Login_When_Credentials_Are_Valid()
        {
            var repo = new FakeUserRepository();
            var userService = new UserService(repo);
            var configMock = new Mock<IConfiguration>();

            configMock.Setup(c => c["Jwt:Key"])
                      .Returns("MINHA_CHAVE_TESTE_12345678910@@###@#@@#@#");


            userService.Register("Lucas Reluz", "lucas77@email.com", "123@abcD", false);

            var authService = new AuthService(repo, configMock.Object);

            var token = authService.Login("lucas77@email.com", "123@abcD");

            Assert.NotNull(token);
        }

        [Fact]
        public void Not_Login_With_Invalid_Password()
        {
            var repo = new FakeUserRepository();
            var userService = new UserService(repo);
            var configMock = new Mock<IConfiguration>();

            configMock.Setup(c => c["Jwt:Key"])
                      .Returns("MINHA_CHAVE_TESTE_12345678910@@###@#@@#@#");

            userService.Register("Lucas", "lucas@email.com", "123@abcD", false);

            var authService = new AuthService(repo, configMock.Object);

            Assert.Throws<BusinessException>(() =>
                authService.Login("lucas@email.com", "senhaErrada"));
        }
    }
}
