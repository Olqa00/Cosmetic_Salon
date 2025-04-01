namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;

public interface IUserService
{
    //Task CheckEmailExistsAsync(Email email, CancellationToken cancellationToken = default);
    //Task CheckUserIdExistsAsync(UserId id, CancellationToken cancellationToken = default);
    //Task CheckUsernameExistsAsync(string username, CancellationToken cancellationToken = default);
    //Task CreateUserAsync(UserEntity user, CancellationToken cancellationToken = default);

    Task<bool> CheckPasswordAsync(string password, string userName, CancellationToken cancellationToken = default);
    Task<UserEntity> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<UserEntity> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<UserEntity> GetUserByNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserEntity>> GetUsersAsync(CancellationToken cancellationToken = default);

    Task RegisterAsync(UserEntity entity, CancellationToken cancellationToken = default);

    //Task<Result<PasswordResetDataResource>> GetPasswordResetData(string userNameOrEmail);
    Task SetPasswordAsync(string id, string token, string password, CancellationToken cancellationToken = default);
    Task SetRoleAsync(string id, string role, CancellationToken cancellationToken = default);
}
