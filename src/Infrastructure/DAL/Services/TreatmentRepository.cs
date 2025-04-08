namespace CosmeticSalon.Infrastructure.DAL.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.Common.Extensions;
using CosmeticSalon.Infrastructure.DAL.Extensions;
using CosmeticSalon.Infrastructure.DAL.Models;
using CosmeticSalon.Infrastructure.Identity.Interfaces;

internal sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly CosmeticSalonDbContext dbContext;
    private readonly ILogger<TreatmentRepository> logger;
    private readonly DbSet<TreatmentDbModel> treatments;
    private readonly IUserMappingService userMappingService;

    public TreatmentRepository(CosmeticSalonDbContext dbContext, ILogger<TreatmentRepository> logger, IUserMappingService userMappingService)
    {
        this.dbContext = dbContext;
        this.logger = logger;
        this.treatments = dbContext.Treatments;
        this.userMappingService = userMappingService;
    }

    public async Task AddTreatmentAsync(TreatmentEntity entity)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(TreatmentId), entity.Id)
        );

        this.logger.LogInformation("Try to add treatment to db");

        var dbModel = entity.ToDbModel();

        await this.dbContext.AddAsync(dbModel);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<TreatmentEntity?> GetByIdAsync(TreatmentId id)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(TreatmentId), id)
        );

        this.logger.LogInformation("Try to get treatment from db");

        var dbModel = await this.treatments
            .FindAsync(id);

        this.logger.LogInformation("Try to map users");

        var users = await this.userMappingService.MapToUserEntitiesAsync(dbModel.TreatmentUsers);

        var result = dbModel?.ToEntity(users);

        return result;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> GetTreatmentsAsync()
    {
        this.logger.LogInformation("Try to get treatments from db");

        var treatmentDbModels = await this.treatments
            .ToListAsync();

        var treatmentEntities = new List<TreatmentEntity>();

        foreach (var treatmentDbModel in treatmentDbModels)
        {
            this.logger.LogInformation("Try to map users");

            var users = await this.userMappingService.MapToUserEntitiesAsync(treatmentDbModel.TreatmentUsers);
            var treatmentEntity = treatmentDbModel.ToEntity(users);
            treatmentEntities.Add(treatmentEntity);
        }

        return treatmentEntities;
    }
}
