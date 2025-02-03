namespace CosmeticSalon.Domain.Interfaces;

using CosmeticSalon.Domain.Entities;

public interface IUserRepository
{
    Task AddUserAsync(UserEntity entity);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity?> GetByIdAsync(UserId id);
    Task<IReadOnlyList<UserEntity>> GetUsersAsync();
}
