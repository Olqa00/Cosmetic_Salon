namespace CosmeticSalon.Infrastructure.Identity.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserService : IUserService
{
    private readonly ILogger<UserService> logger;
    private readonly UserManager<UserDbModel> userManager;

    public UserService(UserManager<UserDbModel> userManager, ILogger<UserService> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
    }

    public async Task<bool> CheckPasswordAsync(string password, string userName, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to check password for user {UserName}", userName);

        var user = await this.userManager.FindByNameAsync(userName);

        if (user is null)
        {
            this.logger.LogError("User {UserName} not found", userName);

            return false;
        }

        var result = await this.userManager.CheckPasswordAsync(user, password);

        return result;
    }

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

    public async Task<IReadOnlyList<UserEntity>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to get users from db");

        var users = this.userManager.Users
            .OrderBy(user => user.NormalizedEmail);

        var userEntities = new List<UserEntity>();

        foreach (var user in users)
        {
            var userRoles = await this.userManager.GetRolesAsync(user); // Error
            var userRole = userRoles.FirstOrDefault();
            var userId = new UserId(user.Id);
            var email = new Email(user.Email);
            var role = new Role(userRole);

            var entity = new UserEntity(userId, email, user.UserName, user.PasswordHash, role);

            userEntities.Add(entity);
        }

        return userEntities;
    }

    public async Task RegisterAsync(UserEntity entity, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to register user in db");

        var userModel = new UserDbModel
        {
            AccessFailedCount = 3,
            Email = entity.Email.Value,
            EmailConfirmed = true, //TODO
            Id = entity.Id.Value,
            LockoutEnabled = false,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            UserName = entity.Username,
        };

        var result = await this.userManager.CreateAsync(userModel, entity.Password);

        if (result.Succeeded is false)
        {
            this.logger.LogError("User creation failed: {Errors}", result.Errors.First().Code);

            throw new Exception(result.Errors.First().Description);
        }
    }

    public Task SetPasswordAsync(string id, string token, string password, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task SetRoleAsync(string id, string role, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
