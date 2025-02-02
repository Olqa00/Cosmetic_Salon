namespace CosmeticSalon.Domain.UnitTests.Entities;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.ValueObjects;

[TestClass]
public sealed class UserEntityTests
{
    private const string EMAIL_STRING = "email@wp.pl";
    private const string FIRST_NAME = "firstName";
    private const string LAST_NAME = "lastName";
    private const string PASSWORD = "password";
    private const string USERNAME = "username";
    private static readonly Email EMAIL = new(EMAIL_STRING);
    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly UserId USER_ID = new(USER_ID_GUID);

    private readonly UserEntity userEntity;

    public UserEntityTests()
    {
        this.userEntity = new UserEntity(USER_ID, EMAIL, USERNAME, PASSWORD, Role.User());
    }

    [TestMethod]
    public void SetFirstName_Should_SetFirstName()
    {
        // Arrange

        // Act
        this.userEntity.SetFirstName(FIRST_NAME);

        // Assert
        this.userEntity.FirstName.Should()
            .Be(FIRST_NAME)
            ;
    }

    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetFirstName_Should_ThrowUserEmptyFirstNameException_When_FirstName_Is_Empty(string firstName)
    {
        // Arrange

        // Act
        var action = () => this.userEntity.SetFirstName(firstName);

        // Assert
        action.Should()
            .Throw<UserEmptyFirstNameException>()
            ;
    }

    [TestMethod]
    public void SetLastName_Should_SetLastName()
    {
        // Arrange

        // Act
        this.userEntity.SetLastName(LAST_NAME);

        // Assert
        this.userEntity.LastName.Should()
            .Be(LAST_NAME)
            ;
    }

    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetLastName_Should_ThrowUserEmptyLastNameException_When_LastName_Is_Empty(string lastName)
    {
        // Arrange

        // Act
        var action = () => this.userEntity.SetLastName(lastName);

        // Assert
        action.Should()
            .Throw<UserEmptyLastNameException>()
            ;
    }
}
