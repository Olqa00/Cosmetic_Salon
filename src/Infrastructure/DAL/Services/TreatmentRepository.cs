namespace CosmeticSalon.Infrastructure.DAL.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.DAL.Models;
using CosmeticSalon.Infrastructure.Extensions;

internal sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly CosmeticSalonDbContext dbContext;
    private readonly ILogger<TreatmentRepository> logger;
    private readonly DbSet<TreatmentDbModel> treatments;

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

        var treatmentUser = new TreatmentUserDbModel
        {
            TreatmentId = entity.Id.Value,
            UserId = Guid.NewGuid(),
        };

        var list = new List<TreatmentUserDbModel>
        {
            treatmentUser,
        };

        var dbModel = new TreatmentDbModel
        {
            Id = entity.Id.Value,
            Name = entity.Name,
            Type = entity.Type,
            TreatmentUsers = list,
        };

        await this.dbContext.AddAsync(dbModel);
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

        var treatment = new TreatmentEntity(id, "", "");

        return treatment;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync()
    {
        this.logger.LogInformation("Try to get treatments from db");

        var result = await this.treatments
            .ToListAsync();

        var id = new TreatmentId(Guid.NewGuid());

        var treatment1 = new TreatmentEntity(id, "", "");

        var treatments = new List<TreatmentEntity>
        {
            treatment1,
        };

        return treatments;
    }
}
