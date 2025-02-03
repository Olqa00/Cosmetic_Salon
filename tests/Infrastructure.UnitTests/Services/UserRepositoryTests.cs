namespace CosmeticSalon.Infrastructure.UnitTests.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Services;

[TestClass]
public sealed class UserRepositoryTests
{
    private const string EMAIL_STRING = "email@o2.pl";
    private const string PASSWORD = "password";
    private const string USERNAME = "username";
    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly Email EMAIL = new(EMAIL_STRING);
    private static readonly UserId USER_ID = new(USER_ID_GUID);

    private static readonly Role USER_ROLE = Role.User();

    private readonly NullLogger<UserRepository> logger = new();
    private readonly UserEntity userEntity;

    public UserRepositoryTests()
    {
        this.userEntity = new UserEntity(USER_ID, EMAIL, USERNAME, PASSWORD, USER_ROLE);
    }

    [TestMethod]
    public async Task AddUserAsync_Should_AddUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "User_Database_1")
            .Options;

        await using var dbContext = new CosmeticSalonDbContext(options);
        var repository = new UserRepository(dbContext, this.logger);

        // Act
        await repository.AddUserAsync(this.userEntity);

        // Assert
        dbContext.Users.Should()
            .HaveCount(1)
            ;

        dbContext.Users.First().Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }

    [TestMethod]
    public async Task GetByEmailAsync_Should_GetUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "User_Database_2")
            .Options;

        await using var dbContext = new CosmeticSalonDbContext(options);

        var repository = new UserRepository(dbContext, this.logger);
        await repository.AddUserAsync(this.userEntity);

        // Act
        var result = await repository.GetByEmailAsync(EMAIL);

        // Assert
        result.Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }

    [TestMethod]
    public async Task GetByIdAsync_Should_GetUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "User_Database_3")
            .Options;

        await using var dbContext = new CosmeticSalonDbContext(options);

        var repository = new UserRepository(dbContext, this.logger);
        await repository.AddUserAsync(this.userEntity);

        // Act
        var result = await repository.GetByIdAsync(USER_ID);

        // Assert
        result.Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }

    [TestMethod]
    public async Task GetByUsernameAsync_Should_GetUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "User_Database_4")
            .Options;

        await using var dbContext = new CosmeticSalonDbContext(options);

        var repository = new UserRepository(dbContext, this.logger);
        await repository.AddUserAsync(this.userEntity);

        // Act
        var result = await repository.GetByUsernameAsync(USERNAME);

        // Assert
        result.Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }

    [TestMethod]
    public async Task GetUsersAsync_Should_GetUsers()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "User_Database_5")
            .Options;

        await using var dbContext = new CosmeticSalonDbContext(options);

        var repository = new UserRepository(dbContext, this.logger);
        await repository.AddUserAsync(this.userEntity);

        // Act
        var result = await repository.GetUsersAsync();

        // Assert
        result.Should()
            .HaveCount(1)
            ;

        result[0].Should()
            .BeEquivalentTo(this.userEntity)
            ;
    }
}
