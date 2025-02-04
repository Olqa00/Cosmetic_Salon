namespace CosmeticSalon.Application.ViewModels;

public sealed record class SignUpUser
{
    [Display(Name = "Email")]
    public string Email { get; init; } = string.Empty;
    public Guid Id { get; init; } = Guid.Empty;
    [Display(Name = "Password")]
    public string Password { get; init; } = string.Empty;
    [Display(Name = "ReapedPassword")]
    public string ReapedPassword { get; init; } = string.Empty;
    [Display(Name = "Username")]
    public string Username { get; init; } = string.Empty;
}
