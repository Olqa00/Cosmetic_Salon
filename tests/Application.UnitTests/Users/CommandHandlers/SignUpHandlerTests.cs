namespace CosmeticSalon.Application.UnitTests.Users.CommandHandlers;

using CosmeticSalon.Application.Users.CommandHandlers;
using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.Security;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.Types;
using CosmeticSalon.Domain.ValueObjects;

[TestClass]
public sealed class SignUpHandlerTests
{
    private const string EMAIL = "email123@wp.pl";
    private const string PASSWORD = "pass123";
    private const string SECURED_PASSWORD = "securedPassword";
    private const string USERNAME = "username";
    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly UserId USER_ID = new(USER_ID_GUID);
    private static readonly Role USER_ROLE = Role.User();
    private static readonly Email USER_EMAIL = new(EMAIL);

    private readonly SignUpHandler handler;

    private readonly NullLogger<SignUpHandler> logger = new();
    private readonly IPasswordManager passwordManager = Substitute.For<IPasswordManager>();
    private readonly IUserService userService = Substitute.For<IUserService>();

    public SignUpHandlerTests()
    {
        this.passwordManager
            .Secure(Arg.Any<string>())
            .Returns(SECURED_PASSWORD);

        this.userService
            .CheckEmailExistsAsync(Arg.Any<Email>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        this.userService
            .CheckUserIdExistsAsync(Arg.Any<UserId>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        this.userService
            .CheckUsernameExistsAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        this.handler = new SignUpHandler(this.logger, this.passwordManager, this.userService);
    }

    [TestMethod]
    public async Task Handle_Should_CreateUser()
    {
        // Arrange
        UserEntity? userEntity = null;

        await this.userService
            .CreateUserAsync(Arg.Do<UserEntity>(user => userEntity = user), Arg.Any<CancellationToken>());

        var command = new SignUp
        {
            Email = EMAIL,
            Password = PASSWORD,
            UserId = USER_ID_GUID,
            Username = USERNAME,
        };

        // Act
        await this.handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedEntity = new UserEntity(USER_ID, USER_EMAIL, USERNAME, SECURED_PASSWORD, USER_ROLE);

        userEntity.Should()
            .BeEquivalentTo(expectedEntity)
            ;
    }
}
