namespace CosmeticSalon.Infrastructure.UnitTests.DAL.Extensions;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.DAL.Extensions;
using CosmeticSalon.Infrastructure.DAL.Models;

[TestClass]
public sealed class TreatmentEntityExtensionsTests
{
    private const string EMAIL_STRING = "easyemail@gmail.com";
    private const string PASSWORD = "Password";
    private const string TREATMENT_NAME = "TreatmentName";
    private const string TREATMENT_TYPE = "TreatmentType";
    private const string USERNAME = "easyusername";
    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();
    private static readonly TreatmentId TREATMENT_ID = new(TREATMENT_ID_GUID);
    private static readonly Guid USER_ID_GUID = Guid.NewGuid();
    private static readonly UserId USER_ID = new(USER_ID_GUID);
    private static readonly Email EMAIL = new(EMAIL_STRING);

    private static readonly TreatmentUserDbModel TREATMENT_USER_DB_MODEL = new()
    {
        TreatmentId = TREATMENT_ID_GUID,
        UserId = USER_ID_GUID,
    };

    private static readonly List<TreatmentUserDbModel> TREATMENT_USER_DB_MODELS =
    [
        TREATMENT_USER_DB_MODEL,
    ];

    private static readonly TreatmentDbModel TREATMENT_DB_MODEL = new()
    {
        Id = TREATMENT_ID_GUID,
        Name = TREATMENT_NAME,
        Type = TREATMENT_TYPE,
        TreatmentUsers = TREATMENT_USER_DB_MODELS,
    };

    private static readonly List<TreatmentDbModel> TREATMENT_DB_MODELS =
    [
        TREATMENT_DB_MODEL,
    ];

    private readonly TreatmentEntity treatmentEntity;
    private readonly UserEntity userEntity;

    public TreatmentEntityExtensionsTests()
    {
        this.userEntity = new UserEntity(USER_ID, EMAIL, USERNAME, PASSWORD, Role.User());
        this.treatmentEntity = new TreatmentEntity(TREATMENT_ID, TREATMENT_TYPE, TREATMENT_NAME);
        this.treatmentEntity.SetUser(this.userEntity);
    }

    [TestMethod]
    public void ToDbModel_Should_ReturnDbModel()
    {
        // Arrange

        // Act
        var result = this.treatmentEntity.ToDbModel();

        // Arrange
        result.Should()
            .BeEquivalentTo(TREATMENT_DB_MODEL)
            ;
    }

    [TestMethod]
    public void ToDbModels_Should_ReturnDbModels()
    {
        // Arrange
        var entities = new List<TreatmentEntity>
        {
            this.treatmentEntity,
        };

        // Act
        var result = entities.ToDbModels();

        // Arrange
        result.Should()
            .BeEquivalentTo(TREATMENT_DB_MODELS)
            ;
    }
}
