namespace CosmeticSalon.Domain.Entities;

using CosmeticSalon.Domain.Exceptions;

public sealed class TreatmentEntity
{
    public List<UserEntity> Employees { get; } = [];
    public TreatmentId Id { get; private init; }
    public string Name { get; private set; }
    public string Type { get; private set; }

    public TreatmentEntity(TreatmentId id, string type, string name)
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

    public void SetUser(UserEntity user)
    {
        this.Employees.Add(user);
    }
}
