namespace CosmeticSalon.Domain.Entities;

public sealed class UserEntity
{
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string FullName => $"{this.FirstName} {this.LastName}";
    public UserId Id { get; private init; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public List<TreatmentEntity> Treatments { get; } = [];
    public string Username { get; private set; }

    public UserEntity(UserId id, string username, string password, string role)
    {
        this.Id = id;
        this.Password = password;
        this.Username = username;

        this.SetRole(role);
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            //throw new TreatmentEmptyNameException(this.Id);
        }

        this.Email = email;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            //throw new TreatmentEmptyNameException(this.Id);
        }

        this.FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            //throw new TreatmentEmptyNameException(this.Id);
        }

        this.LastName = lastName;
    }

    public void SetRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            //throw new TreatmentEmptyNameException(this.Id);
        }

        this.Role = role;
    }
}
