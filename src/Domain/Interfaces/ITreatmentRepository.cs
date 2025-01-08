namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;

public interface ITreatmentRepository
{
    Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync();
}
