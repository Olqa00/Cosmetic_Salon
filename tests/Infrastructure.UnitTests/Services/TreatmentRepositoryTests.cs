namespace CosmeticSalon.Infrastructure.UnitTests.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Services;

[TestClass]
public sealed class TreatmentRepositoryTests
{
    private const string TREATMENT_NAME = "name";
    private const string TREATMENT_TYPE = "type";
    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();
    private static readonly TreatmentId TREATMENT_ID = new(TREATMENT_ID_GUID);

    private readonly NullLogger<TreatmentRepository> logger = new();
    private readonly TreatmentEntity treatmentEntity;

    public TreatmentRepositoryTests()
    {
        this.treatmentEntity = new TreatmentEntity(TREATMENT_ID, TREATMENT_TYPE, TREATMENT_NAME);
    }

    [TestMethod]
    public async Task AddTreatmentAsync_Should_AddTreatment()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Database_1")
            .Options;

        await using var sut = new CosmeticSalonDbContext(options);
        var repository = new TreatmentRepository(sut, this.logger);

        // Act
        await repository.AddTreatmentAsync(this.treatmentEntity);

        // Assert
        sut.Treatments.Should()
            .HaveCount(1)
            ;

        sut.Treatments.First().Should()
            .BeEquivalentTo(this.treatmentEntity)
            ;
    }

    [TestMethod]
    public async Task GetByIdAsync_Should_GetTreatment()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Database_2")
            .Options;

        await using var sut = new CosmeticSalonDbContext(options);
        var repository = new TreatmentRepository(sut, this.logger);
        await repository.AddTreatmentAsync(this.treatmentEntity);

        // Act
        var result = await repository.GetByIdAsync(TREATMENT_ID);

        // Assert
        result.Should()
            .BeEquivalentTo(this.treatmentEntity)
            ;
    }

    [TestMethod]
    public async Task GetTreatmentsAsync_Should_GetTreatments()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CosmeticSalonDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Database_3")
            .Options;

        await using var sut = new CosmeticSalonDbContext(options);
        var repository = new TreatmentRepository(sut, this.logger);
        await repository.AddTreatmentAsync(this.treatmentEntity);

        // Act
        var result = await repository.GetTreatmentsAsync();

        // Assert
        result.Should()
            .HaveCount(1)
            ;

        result[0].Should()
            .BeEquivalentTo(this.treatmentEntity)
            ;
    }
}
