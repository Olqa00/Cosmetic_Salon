namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;

public interface ITreatmentRepository
{
    Task AddTreatmentAsync(TreatmentEntity entity);
    Task<TreatmentEntity?> GetByIdAsync(TreatmentId id);
    Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync();
}
