namespace CosmeticSalon.Application.Users.Commands;

public sealed record class SignIn : IRequest
{
    public required string Password { get; init; }
    public bool RememberMe { get; init; }
    public required string Username { get; init; }
}
