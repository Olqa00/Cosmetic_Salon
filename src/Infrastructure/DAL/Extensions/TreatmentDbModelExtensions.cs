namespace CosmeticSalon.Infrastructure.DAL.Extensions;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL.Models;

public static class TreatmentDbModelExtensions
{
    public static List<TreatmentEntity> ToEntities(this IReadOnlyList<TreatmentDbModel> dbModels, IReadOnlyList<UserEntity> userEntities)
    {
        var entities = dbModels
            .Select(entity => entity.ToEntity(userEntities))
            .ToList();

        return entities;
    }

    public static TreatmentEntity ToEntity(this TreatmentDbModel dbModel, IReadOnlyList<UserEntity> userEntities)
    {
        var treatmentId = new TreatmentId(dbModel.Id);

        var entity = new TreatmentEntity(treatmentId, dbModel.Type, dbModel.Name);

        if (dbModel.TreatmentUsers.Count != userEntities.Count)
        {
            //TODO exception
        }

        foreach (var user in userEntities)
        {
            entity.SetUser(user);
        }

        return entity;
    }
}
