namespace CosmeticSalon.Infrastructure.Identity.Extensions;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL.Models;

internal static class UserEntityExtensions
{
    public static List<TreatmentUserDbModel> ToTreatmentUserDbModelsWithTreatmentId(this List<UserEntity> entity, Guid treatmentId)
    {
        return entity.Select(user => user.ToTreatmentUserDbModelWithTreatmentId(treatmentId))
            .ToList();
    }

    public static TreatmentUserDbModel ToTreatmentUserDbModelWithTreatmentId(this UserEntity entity, Guid treatmentId)
    {
        return new TreatmentUserDbModel
        {
            UserId = entity.Id.Value,
            TreatmentId = treatmentId,
        };
    }
}
