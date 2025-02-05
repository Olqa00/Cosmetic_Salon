﻿namespace CosmeticSalon.Domain.UnitTests.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.Services;
using CosmeticSalon.Domain.ValueObjects;

[TestClass]
public sealed class UserServiceTests
{
    private const string EMAIL = "email@o2.pl";
    private const string PASSWORD = "password";
    private const string USERNAME = "username";
    private static readonly Email USER_EMAIL = new(EMAIL);
    private static readonly CancellationToken CANCELLATION_TOKEN = CancellationToken.None;

    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly UserId USER_ID = new(USER_ID_GUID);

    private static readonly Role USER_ROLE = Role.User();

    private readonly NullLogger<UserService> logger = new();
    private readonly UserEntity userEntity;
    private readonly IUserRepository userRepository = Substitute.For<IUserRepository>();

    public UserServiceTests()
    {
        this.userEntity = new UserEntity(USER_ID, USER_EMAIL, USERNAME, PASSWORD, USER_ROLE);
    }

    [TestMethod]
    public async Task CheckEmailExistenceAsync_Should_NotThrowException()
    {
        // Arrange
        this.userRepository
            .GetByEmailAsync(USER_EMAIL)
            .Returns((UserEntity?)null);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckEmailExistenceAsync(USER_EMAIL, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .NotThrowAsync()
            ;
    }

    [TestMethod]
    public async Task CheckEmailExistenceAsync_Should_ThrowsEmailAlreadyExistsException()
    {
        // Arrange
        this.userRepository
            .GetByEmailAsync(USER_EMAIL)
            .Returns(this.userEntity);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckEmailExistenceAsync(USER_EMAIL, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .ThrowAsync<EmailAlreadyExistsException>()
            ;
    }

    [TestMethod]
    public async Task CheckUserIdExistenceAsync_Should_NotThrowException()
    {
        // Arrange
        this.userRepository
            .GetByIdAsync(USER_ID)
            .Returns((UserEntity?)null);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckUserIdExistenceAsync(USER_ID, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .NotThrowAsync()
            ;
    }

    [TestMethod]
    public async Task CheckUserIdExistenceAsync_Should_ThrowsUserIdAlreadyExistsException()
    {
        // Arrange
        this.userRepository
            .GetByIdAsync(USER_ID)
            .Returns(this.userEntity);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckUserIdExistenceAsync(USER_ID, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .ThrowAsync<UserIdAlreadyExistsException>()
            ;
    }

    [TestMethod]
    public async Task CheckUsernameExistenceAsync_Should_NotThrowException()
    {
        // Arrange
        this.userRepository
            .GetByUsernameAsync(USERNAME)
            .Returns((UserEntity?)null);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckUsernameExistenceAsync(USERNAME, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .NotThrowAsync()
            ;
    }

    [TestMethod]
    public async Task CheckUsernameExistenceAsync_Should_ThrowsUsernameAlreadyExistsException()
    {
        // Arrange
        this.userRepository
            .GetByUsernameAsync(USERNAME)
            .Returns(this.userEntity);

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        var action = async () => await userService.CheckUsernameExistenceAsync(USERNAME, CANCELLATION_TOKEN);

        // Assert
        await action.Should()
                .ThrowAsync<UsernameAlreadyExistsException>()
            ;
    }

    [TestMethod]
    public async Task CreateUserAsync_Should_CreateUser()
    {
        // Arrange
        UserEntity? createdUserEntity = null;

        await this.userRepository
            .AddUserAsync(Arg.Do<UserEntity>(user => createdUserEntity = user));

        var userService = new UserService(this.logger, this.userRepository);

        // Act
        await userService.CreateUserAsync(this.userEntity, CANCELLATION_TOKEN);

        // Assert
        createdUserEntity.Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }
}
