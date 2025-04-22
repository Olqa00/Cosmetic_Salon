//namespace CosmeticSalon.Infrastructure.UnitTests.DAL.Services;

//using CosmeticSalon.Domain.Entities;
//using CosmeticSalon.Domain.ValueObjects;
//using CosmeticSalon.Infrastructure.DAL;
//using CosmeticSalon.Infrastructure.DAL.Models;
//using CosmeticSalon.Infrastructure.DAL.Services;
//using CosmeticSalon.Infrastructure.Identity.Interfaces;

//[TestClass]
//public sealed class TreatmentRepositoryTests
//{
//    private const string EMAIL_STRING = "testemail@gmail.com";
//    private const string PASSWORD = "password";
//    private const string TREATMENT_NAME = "name";
//    private const string TREATMENT_TYPE = "type";
//    private const string USERNAME = "username";

//    private static readonly Email EMAIL = new(EMAIL_STRING);

//    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();
//    private static readonly Guid USER_ID_GUID = Guid.NewGuid();

//    private static readonly TreatmentUserDbModel TREATMENT_USER_DB_MODEL = new()
//    {
//        UserId = USER_ID_GUID,
//        TreatmentId = TREATMENT_ID_GUID,
//    };

//    private static readonly List<TreatmentUserDbModel> TREATMENT_USER_DB_MODEL_LIST =
//    [
//        TREATMENT_USER_DB_MODEL,
//    ];

//    private static readonly UserId USER_ID = new(USER_ID_GUID);

//    private static readonly TreatmentDbModel TREATMENT_DB_MODEL = new()
//    {
//        Id = TREATMENT_ID_GUID,
//        Name = TREATMENT_NAME,
//        Type = TREATMENT_TYPE,
//        TreatmentUsers = TREATMENT_USER_DB_MODEL_LIST,
//    };

//    private static readonly TreatmentId TREATMENT_ID = new(TREATMENT_ID_GUID);

//    private readonly NullLogger<TreatmentRepository> logger = new();
//    private readonly TreatmentEntity treatmentEntity;
//    private readonly UserEntity userEntity;
//    private readonly IUserMappingService userMappingService = Substitute.For<IUserMappingService>();

//    public TreatmentRepositoryTests()
//    {
//        this.userEntity = new UserEntity(USER_ID, EMAIL, USERNAME, PASSWORD, Role.User());
//        this.treatmentEntity = new TreatmentEntity(TREATMENT_ID, TREATMENT_TYPE, TREATMENT_NAME);
//        this.treatmentEntity.SetUser(this.userEntity);
//    }

//    [TestMethod]
//    public async Task AddTreatmentAsync_Should_AddTreatment()
//    {
//        // Arrange
//        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
//            .UseInMemoryDatabase(databaseName: "Test_Database_1")
//            .Options;

//        await using var sut = new CosmeticSalonDbContext(options);
//        var repository = new TreatmentRepository(sut, this.logger, this.userMappingService);

//        // Act
//        await repository.AddTreatmentAsync(this.treatmentEntity);

//        // Assert
//        sut.Treatments.Should()
//            .HaveCount(1)
//            ;

//        sut.Treatments.First().Should()
//            .BeEquivalentTo(TREATMENT_DB_MODEL)
//            ;
//    }

//    [TestMethod]
//    public async Task GetByIdAsync_Should_GetTreatment()
//    {
//        // Arrange
//        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
//            .UseInMemoryDatabase(databaseName: "Test_Database_2")
//            .Options;

//        await using var sut = new CosmeticSalonDbContext(options);
//        var repository = new TreatmentRepository(sut, this.logger, this.userMappingService);
//        await repository.AddTreatmentAsync(this.treatmentEntity);

//        // Act
//        var result = await repository.GetByIdAsync(TREATMENT_ID);

//        // Assert
//        result.Should()
//            .BeEquivalentTo(this.treatmentEntity)
//            ;
//    }

//    [TestMethod]
//    public async Task GetTreatmentsAsync_Should_GetTreatments()
//    {
//        // Arrange
//        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
//            .UseInMemoryDatabase(databaseName: "Test_Database_3")
//            .Options;

//        await using var sut = new CosmeticSalonDbContext(options);
//        var repository = new TreatmentRepository(sut, this.logger, this.userMappingService);
//        await repository.AddTreatmentAsync(this.treatmentEntity);

//        // Act
//        var result = await repository.GetTreatmentsAsync();

//        // Assert
//        result.Should()
//            .HaveCount(1)
//            ;

//        result[0].Should()
//            .BeEquivalentTo(this.treatmentEntity)
//            ;
//    }
//}


