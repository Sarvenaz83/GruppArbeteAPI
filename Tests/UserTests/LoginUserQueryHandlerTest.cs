//using Application.Queries.UserQueries.LoginUser;
//using Domain.Models;
//using Infrastructure.Repository.UserRepository;
//using Moq;
//using NUnit.Framework;

//namespace Tests.UserTests
//{
//    [TestFixture]
//    public class LoginUserQueryHandlerTest
//    {
//        private Mock<IUserRepository> _mockUserRepository;
//        private Mock<ITokenGenerator> _mockTokenGenerator;
//        private LoginUserQueryHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _mockUserRepository = new Mock<IUserRepository>();
//            _mockTokenGenerator = new Mock<ITokenGenerator>();
//            _handler = new LoginUserQueryHandler(_mockUserRepository.Object, _mockTokenGenerator.Object);
//        }

//        [Test]
//        public async Task Handle_ValidCredentials_ReturnsToken()
//        {
//            // Arrange
//            var username = "test";
//            var password = "password";
//            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
//            var user = new User { UserName = username, Password = hashedPassword };
//            var token = "token";

//            _mockUserRepository.Setup(repo => repo.FindByUsernameAsync(username)).ReturnsAsync(user);
//            _mockTokenGenerator.Setup(gen => gen.JwtTokenGenerate(user)).Returns(token);

//            // Act
//            var result = await _handler.Handle(new LoginUserQuery { Username = username, Password = password }, default);

//            // Assert
//            Assert.That(result, Is.EqualTo(token));
//        }

//        [Test]
//        public async Task Handle_InvalidCredentials_DoesNotReturnToken()
//        {
//            // Arrange
//            var username = "test";
//            var incorrectPassword = "wrong_password";
//            var correctPassword = "password";
//            var hashedCorrectPassword = BCrypt.Net.BCrypt.HashPassword(correctPassword);
//            var user = new User { UserName = username, Password = hashedCorrectPassword };

//            _mockUserRepository.Setup(repo => repo.FindByUsernameAsync(username)).ReturnsAsync(user);

//            // Act
//            var result = await _handler.Handle(new LoginUserQuery { Username = username, Password = incorrectPassword }, default);

//            // Assert
//            Assert.That(result, Is.Null);
//        }
//    }
//}
