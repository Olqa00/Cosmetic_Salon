namespace CosmeticSalon.Infrastructure.Identity.Models;

public sealed class UserDbModel : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
