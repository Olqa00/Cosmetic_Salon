namespace CosmeticSalon.Domain.Services;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.Extensions;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;

internal sealed class UserService : IUserService
{
    private readonly ILogger<UserService> logger;
    private readonly IUserRepository userRepository;

    public UserService(ILogger<UserService> logger, IUserRepository userRepository)
    {
        this.logger = logger;
        this.userRepository = userRepository;
    }

    public async Task CheckEmailExistsAsync(Email email, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to check if user with email {email} exists", email);

        var user = await this.userRepository.GetByEmailAsync(email);

        if (user is not null)
        {
            throw new EmailAlreadyExistsException(email);
        }
    }

    public async Task CheckUserIdExistsAsync(UserId id, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to check if user with id {id} exists", id);

        var user = await this.userRepository.GetByIdAsync(id);

        if (user is not null)
        {
            throw new UserIdAlreadyExistsException(id);
        }
    }

    public async Task CheckUsernameExistsAsync(string username, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to check if user with username {username} exists", username);

        var user = await this.userRepository.GetByUsernameAsync(username);

        if (user is not null)
        {
            throw new UsernameAlreadyExistsException(username);
        }
    }

    public async Task CreateUserAsync(UserEntity user, CancellationToken cancellationToken = default)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(UserId), user.Id)
        );

        this.logger.LogInformation("Try to create user");

        await this.userRepository.AddUserAsync(user);
    }
}
