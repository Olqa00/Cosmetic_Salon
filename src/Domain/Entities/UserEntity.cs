namespace CosmeticSalon.Domain.Entities;

using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.ValueObjects;

public sealed class UserEntity
{
    public Email Email { get; private set; }
    public string FirstName { get; private set; }
    public string FullName => $"{this.FirstName} {this.LastName}";
    public UserId Id { get; private init; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public List<TreatmentEntity> Treatments { get; } = [];
    public string Username { get; private set; }

    public UserEntity(UserId id, Email email, string username, string password, Role role)
    {
        this.Id = id;
        this.Email = email;
        this.Password = password;
        this.Username = username;
        this.Role = role;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new UserEmptyFirstNameException(this.Id);
        }

        this.FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new UserEmptyLastNameException(this.Id);
        }

        this.LastName = lastName;
    }
}
