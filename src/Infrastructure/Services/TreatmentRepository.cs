namespace CosmeticSalon.Infrastructure.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.DAL;

internal sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly CosmeticSalonDbContext dbContext;
    private readonly DbSet<TreatmentEntity> treatments;

    public TreatmentRepository(CosmeticSalonDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.treatments = dbContext.Treatments;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync()
    {
        var result = await this.treatments
            .Include(treatment => treatment.Employees)
            .ToListAsync();

        return result;
    }
}
