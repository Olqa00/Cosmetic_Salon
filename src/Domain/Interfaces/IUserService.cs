namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;

public interface IUserService
{
    Task CheckEmailExistsAsync(Email email, CancellationToken cancellationToken = default);
    Task CheckUserIdExistsAsync(UserId id, CancellationToken cancellationToken = default);
    Task CheckUsernameExistsAsync(string username, CancellationToken cancellationToken = default);
    Task CreateUserAsync(UserEntity user, CancellationToken cancellationToken = default);
}
