namespace CosmeticSalon.Domain.UnitTests.Entities;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.Types;

[TestClass]
public sealed class TreatmentEntityTests
{
    private const string DEFAULT_NAME = "name";
    private const string DEFAULT_TYPE = "type";
    private static readonly Guid TREATMENT_ID_GUID = Guid.NewGuid();
    private static readonly TreatmentId TREATMENT_ID = new(TREATMENT_ID_GUID);

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
