namespace CosmeticSalon.Domain.UnitTests.Entities;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;

[TestClass]
public sealed class TreatmentEntityTests
{
    private const string DEFAULT_NAME = "name";
    private const string DEFAULT_TYPE = "type";
    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();
    private static readonly TreatmentId TREATMENT_ID = new(TREATMENT_ID_GUID);

    [TestMethod]
    public void SetName_Should_SetName()
    {
        // Arrange

        // Act
        var treatmentEntity = new TreatmentEntity(TREATMENT_ID, DEFAULT_TYPE, DEFAULT_NAME);

        // Assert
        treatmentEntity.Name.Should()
            .Be(DEFAULT_NAME)
            ;
    }

    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetName_Should_ThrowTreatmentEmptyNameException_When_Name_Is_Empty(string name)
    {
        // Arrange

        // Act
        var action = () => new TreatmentEntity(TREATMENT_ID, DEFAULT_TYPE, name);

        // Assert
        action.Should()
            .Throw<TreatmentEmptyNameException>()
            ;
    }

    [TestMethod]
    public void SetType_Should_SetType()
    {
        // Arrange

        // Act
        var treatmentEntity = new TreatmentEntity(TREATMENT_ID, DEFAULT_TYPE, DEFAULT_NAME);

        // Assert
        treatmentEntity.Type.Should()
            .Be(DEFAULT_TYPE)
            ;
    }

    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetType_Should_ThrowTreatmentEmptyTypeException_When_Type_Is_Empty(string type)
    {
        // Arrange

        // Act
        var action = () => new TreatmentEntity(TREATMENT_ID, type, DEFAULT_NAME);

        // Assert
        action.Should()
            .Throw<TreatmentEmptyTypeException>()
            ;
    }
}
