namespace CosmeticSalon.Infrastructure.UnitTests.Identity.Extensions;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.DAL.Models;
using CosmeticSalon.Infrastructure.Identity.Extensions;

[TestClass]
internal class UserEntityExtensionsTests
{
    private const string EMAIL_STRING = "easyemail@gmail.com";
    private const string PASSWORD = "Password";
    private const string USERNAME = "easyusername";
    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly UserId USER_ID = new(USER_ID_GUID);
    private static readonly Email EMAIL = new(EMAIL_STRING);
    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();

    private static readonly TreatmentUserDbModel TREATMENT_USER_DB_MODEL = new()
    {
        TreatmentId = TREATMENT_ID_GUID,
        UserId = USER_ID_GUID,
    };

    private static readonly List<TreatmentUserDbModel> TREATMENT_USER_DB_MODELS =
    [
        TREATMENT_USER_DB_MODEL,
    ];

    private readonly UserEntity userEntity;

    public UserEntityExtensionsTests()
    {
        this.userEntity = new UserEntity(USER_ID, EMAIL, USERNAME, PASSWORD, Role.User());
    }

    [TestMethod]
    public void ToTreatmentUserDbModelsWithTreatmentId_Should_ReturnTreatmentUserDbModels()
    {
        // Arrange
        var userEntities = new List<UserEntity>
        {
            this.userEntity,
        };

        // Act
        var result = userEntities.ToTreatmentUserDbModelsWithTreatmentId(TREATMENT_ID_GUID);

        // Assert
        result.Should()
            .BeEquivalentTo(TREATMENT_USER_DB_MODELS)
            ;
    }

    [TestMethod]
    public void ToTreatmentUserDbModelWithTreatmentId_Should_ReturnTreatmentUserDbModel()
    {
        // Arrange

        // Act
        var result = this.userEntity.ToTreatmentUserDbModelWithTreatmentId(TREATMENT_ID_GUID);

        // Assert
        result.Should()
            .BeEquivalentTo(TREATMENT_USER_DB_MODEL)
            ;
    }
}
