namespace CosmeticSalon.Application.Users.ViewModels;

public sealed record class SignInUser
{
    [Display(Name = "Password")]
    public string Password { get; init; } = string.Empty;
    [Display(Name = "Username")]
    public string Username { get; init; } = string.Empty;
}
