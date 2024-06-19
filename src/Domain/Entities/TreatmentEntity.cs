namespace CosmeticSalon.Domain.Entities;

using CosmeticSalon.Domain.Exceptions;

public sealed class TreatmentEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Type { get; private set; } = string.Empty;

    public TreatmentEntity(Guid id, string type, string name)
    {
        this.Id = id;
        this.SetName(name);
        this.SetType(type);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new TreatmentEmptyNameException(this.Id);
        }

        this.Name = name;
    }

    public void SetType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new TreatmentEmptyTypeException(this.Id);
        }

        this.Type = type;
    }
}
