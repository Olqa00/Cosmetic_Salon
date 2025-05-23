﻿namespace CosmeticSalon.Infrastructure.DAL.Models;

public sealed class TreatmentUserDbModel
{
    public int RecordId { get; set; }
    public TreatmentDbModel Treatment { get; set; } = null!;
    public Guid TreatmentId { get; set; }
    public Guid UserId { get; set; }
}
