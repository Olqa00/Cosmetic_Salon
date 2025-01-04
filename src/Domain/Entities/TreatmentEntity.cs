﻿namespace CosmeticSalon.Domain.Entities;

using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.Types;

public sealed class TreatmentEntity
{
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
}
