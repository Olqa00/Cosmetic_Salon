namespace CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserDbModel : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
