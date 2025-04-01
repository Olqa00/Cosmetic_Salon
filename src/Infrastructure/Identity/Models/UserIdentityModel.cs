namespace CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserIdentityModel : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
