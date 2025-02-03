namespace CosmeticSalon.Infrastructure.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Extensions;

internal sealed class UserRepository : IUserRepository
{
    private readonly CosmeticSalonDbContext dbContext;
    private readonly ILogger<UserRepository> logger;
    private readonly DbSet<UserEntity> users;

    public UserRepository(CosmeticSalonDbContext dbContext, ILogger<UserRepository> logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
        this.users = dbContext.Users;
    }

    public async Task AddUserAsync(UserEntity entity)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(UserId), entity.Id)
        );

        this.logger.LogInformation("Try to add user to db");

        await this.dbContext.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(Email), email)
        );

        this.logger.LogInformation("Try to get user by email from db");

        var result = await this.users
            .SingleOrDefaultAsync(user => user.Email == email);

        return result;
    }

    public async Task<UserEntity?> GetByIdAsync(UserId id)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(UserId), id)
        );

        this.logger.LogInformation("Try to get user by id from db");

        var result = await this.users
            .FindAsync(id);

        return result;
    }

    public async Task<IReadOnlyList<UserEntity>> GetUsersAsync()
    {
        this.logger.LogInformation("Try to get users from db");

        var result = await this.users
            .ToListAsync();

        return result;
    }
}
