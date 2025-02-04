namespace CosmeticSalon.WebUI.Models;

public sealed class SignUpUser
{
    public string Email { get; init; }
    public Guid Id { get; init; }
    public string Password { get; init; }
    public string ReapedPassword { get; init; }
    public string Username { get; init; }
}
