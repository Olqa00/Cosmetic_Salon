namespace CosmeticSalon.Application.Commands;

using CosmeticSalon.Application.Abstractions;

public sealed record SignUp : ICommand
{
    public required string Password { get; init; }
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
}
