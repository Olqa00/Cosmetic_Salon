namespace CosmeticSalon.Domain.UnitTests.Entities;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;

[TestClass]
public sealed class TreatmentEntityTests
{
    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetName_Should_ThrowTreatmentEmptyNameException_When_Name_Is_Empty(string name)
    {
        // Arrange
        var treatmentIdGuid = Guid.NewGuid();
        var type = "type";

        // Act
        var action = () => new TreatmentEntity(treatmentIdGuid, type, name);

        // Assert
        action.Should()
            .Throw<TreatmentEmptyNameException>()
            ;
    }

    [DataTestMethod, DataRow(""), DataRow("       ")]
    public void SetType_Should_ThrowTreatmentEmptyTypeException_When_Type_Is_Empty(string type)
    {
        // Arrange
        var treatmentIdGuid = Guid.NewGuid();
        var name = "name";

        // Act
        var action = () => new TreatmentEntity(treatmentIdGuid, type, name);

        // Assert
        action.Should()
            .Throw<TreatmentEmptyTypeException>()
            ;
    }
}
