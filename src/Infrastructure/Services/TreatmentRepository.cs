namespace CosmeticSalon.Infrastructure.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Extensions;

internal sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly CosmeticSalonDbContext dbContext;
    private readonly ILogger<TreatmentRepository> logger;
    private readonly DbSet<TreatmentEntity> treatments;

    public TreatmentRepository(CosmeticSalonDbContext dbContext, ILogger<TreatmentRepository> logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
        this.treatments = dbContext.Treatments;
    }

    public async Task AddTreatmentAsync(TreatmentEntity entity)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(TreatmentId), entity.Id)
        );

        this.logger.LogInformation("Try to add treatment to db");

        await this.dbContext.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<TreatmentEntity?> GetByIdAsync(TreatmentId id)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(TreatmentId), id)
        );

        this.logger.LogInformation("Try to get treatment from db");

        var result = await this.treatments
            .FindAsync(id);

        return result;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync()
    {
        this.logger.LogInformation("Try to get treatments from db");

        var result = await this.treatments
            .ToListAsync();

        return result;
    }
}
