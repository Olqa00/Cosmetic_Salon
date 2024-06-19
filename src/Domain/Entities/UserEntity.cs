namespace CosmeticSalon.Domain.Entities;

public sealed class UserEntity
{
    public string Email { get; } = string.Empty;
    public string FirstName { get; } = string.Empty;
    public string FullName => $"{this.FirstName} {this.LastName}";
    public Guid Id { get; }
    public string LastName { get; } = string.Empty;
    public string Password { get; }
    public string Role { get; private set; } = string.Empty;
    public string Username { get; } = string.Empty;

    public UserEntity(Guid id, string username, string email, string password, string firstName, string lastName, string role)
    {
        this.Id = id;
        this.Password = password;
        this.Role = role;
        this.Username = username;
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Role = role;
    }
}
