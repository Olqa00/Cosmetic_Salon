namespace CosmeticSalon.Infrastructure.Identity.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.Common.Extensions;
using CosmeticSalon.Infrastructure.DAL.Models;
using CosmeticSalon.Infrastructure.Identity.Interfaces;

internal sealed class UserMappingService : IUserMappingService
{
    private readonly ILogger<UserMappingService> logger;
    private readonly IUserService userService;

    public UserMappingService(ILogger<UserMappingService> logger, IUserService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    public async Task<IReadOnlyList<UserEntity>> MapToUserEntitiesAsync(IReadOnlyList<TreatmentUserDbModel> userDbModels, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to map treatment db users to user entities");

        var userEntities = new List<UserEntity>();

        foreach (var userDbModel in userDbModels)
        {
            using var loggerScope = this.logger.BeginPropertyScope(
                (nameof(UserId), userDbModel.UserId)
            );

            this.logger.LogInformation("Try to map treatment db user to user entity");

            var userId = userDbModel.UserId.ToString();

            var user = await this.userService.GetUserByIdAsync(userId, cancellationToken);
            userEntities.Add(user);
        }

        return userEntities;
    }

    public async Task<UserEntity> MapToUserEntityAsync(TreatmentUserDbModel userDbModel, CancellationToken cancellationToken = default)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(UserId), userDbModel.UserId)
        );

        this.logger.LogInformation("Try to map treatment db user to user entity");

        var userId = userDbModel.UserId.ToString();

        var user = await this.userService.GetUserByIdAsync(userId, cancellationToken);

        return user;
    }
}
