namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;

public interface IUserRepository
{
    Task AddUserAsync(UserEntity entity);
    Task<UserEntity?> GetByEmailAsync(Email email);
    Task<UserEntity?> GetByIdAsync(UserId id);
    Task<UserEntity?> GetByUsernameAsync(string username);
    Task<IReadOnlyList<UserEntity>> GetUsersAsync();
}
