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

    public async Task AddTreatmentAsync(TreatmentEntity entity)
    {
        await this.dbContext.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<TreatmentEntity?> GetByIdAsync(TreatmentId id)
    {
        var result = await this.treatments
            .FindAsync(id);

        return result;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync()
    {
        var result = await this.treatments
            //.Include(treatment => treatment.Employees.AsQueryable())
            .ToListAsync();

        return result;
    }
}
