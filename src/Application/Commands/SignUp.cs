namespace CosmeticSalon.Application.Commands;

using CosmeticSalon.Application.Abstractions;

public sealed record SignUp(Guid UserId, string Username, string Email, string Password, string FirstName, string LastName, string Role) : ICommand;
