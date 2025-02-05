namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;

public interface IUserService
{
    Task CheckEmailExistenceAsync(Email email, CancellationToken cancellationToken = default);
    Task CheckUserIdExistenceAsync(UserId id, CancellationToken cancellationToken = default);
    Task CheckUsernameExistenceAsync(string username, CancellationToken cancellationToken = default);
    Task CreateUserAsync(UserEntity user, CancellationToken cancellationToken = default);
}
