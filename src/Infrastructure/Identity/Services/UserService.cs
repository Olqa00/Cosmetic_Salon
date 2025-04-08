namespace CosmeticSalon.Infrastructure.Identity.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.Identity.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserService : IUserService
{
    private readonly ILogger<UserService> logger;
    private readonly UserManager<UserDbModel> userManager;
    private readonly IUserMappingService userMappingService;

    public UserService(UserManager<UserDbModel> userManager, ILogger<UserService> logger, IUserMappingService userMappingService)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.userMappingService = userMappingService;
    }

    public Task<bool> CheckPasswordAsync(string password, string userName, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UserEntity> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public async Task<UserEntity> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var userDbModel = await this.userManager.FindByIdAsync(id);

        if (userDbModel is null)
        {
            return null;
        }

        var userRoles = await this.userManager.GetRolesAsync(userDbModel);
        var userRole = userRoles.FirstOrDefault();
        var userId = new UserId(userDbModel.Id);
        var email = new Email(userDbModel.Email);
        var role = new Role(userRole);

        var entity = new UserEntity(userId, email, userDbModel.UserName, userDbModel.PasswordHash, role);

        return entity;
    }

    public Task<UserEntity> GetUserByNameAsync(string userName, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserEntity>> GetUsersAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public async Task RegisterAsync(UserEntity entity, CancellationToken cancellationToken = default)
    {
        var userModel = new UserDbModel
        {
            AccessFailedCount = 3,
            Email = entity.Email.Value,
            EmailConfirmed = false,
            Id = entity.Id.Value,
            LockoutEnabled = false,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };

        await this.userManager.CreateAsync(userModel, entity.Password);
    }

    public Task SetPasswordAsync(string id, string token, string password, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task SetRoleAsync(string id, string role, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
