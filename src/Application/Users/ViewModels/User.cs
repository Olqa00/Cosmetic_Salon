namespace CosmeticSalon.Application.Users.ViewModels;

public sealed record class User
{
    [Display(Name = "Fullname")]
    public string Fullname { get; init; } = string.Empty;
    public Guid Id { get; init; } = Guid.Empty;
    [Display(Name = "Role")]
    public string Role { get; init; } = string.Empty;
    [Display(Name = "Username")]
    public string Username { get; init; } = string.Empty;
}
