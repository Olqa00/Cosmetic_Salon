namespace CosmeticSalon.Application.Commands;

public sealed record class SignUp : IRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
}
