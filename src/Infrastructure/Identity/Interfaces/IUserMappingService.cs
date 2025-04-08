namespace CosmeticSalon.Infrastructure.Identity.Interfaces;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL.Models;

public interface IUserMappingService
{
    Task<IReadOnlyList<UserEntity>> MapToUserEntitiesAsync(IReadOnlyList<TreatmentUserDbModel> userDbModels, CancellationToken cancellationToken = default);
    Task<UserEntity> MapToUserEntityAsync(TreatmentUserDbModel userDbModel, CancellationToken cancellationToken = default);
}
