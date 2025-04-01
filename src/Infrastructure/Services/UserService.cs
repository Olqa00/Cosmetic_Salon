﻿namespace CosmeticSalon.Infrastructure.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserService : IUserService
{
    private readonly ILogger<UserService> logger;
    private readonly UserManager<UserIdentityModel> userManager;

    public UserService(UserManager<UserIdentityModel> userManager, ILogger<UserService> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
    }

    public Task<bool> CheckPasswordAsync(string password, string userName, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UserEntity> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UserEntity> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UserEntity> GetUserByNameAsync(string userName, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserEntity>> GetUsersAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public async Task RegisterAsync(UserEntity entity, CancellationToken cancellationToken = default)
    {
        var userModel = new UserIdentityModel
        {
            AccessFailedCount = 3,
            Email = entity.Email.Value,
            EmailConfirmed = false,
            Id = entity.Id.Value.ToString(),
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
