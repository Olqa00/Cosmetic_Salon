namespace CosmeticSalon.Infrastructure.DAL.Extensions;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL.Models;
using CosmeticSalon.Infrastructure.Identity.Extensions;

internal static class TreatmentEntityExtensions
{
    public static TreatmentDbModel ToDbModel(this TreatmentEntity entity)
    {
        var treatmentId = entity.Id.Value;
        var users = entity.Employees.ToTreatmentUserDbModelsWithTreatmentId(treatmentId);

        var dbModel = new TreatmentDbModel
        {
            Id = treatmentId,
            Name = entity.Name,
            Type = entity.Type,
            TreatmentUsers = users,
        };

        return dbModel;
    }

    public static List<TreatmentDbModel> ToDbModels(this List<TreatmentEntity> entities)
    {
        return entities.Select(entity => entity.ToDbModel())
            .ToList();
    }
}
