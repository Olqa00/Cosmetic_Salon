namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Abstractions;
using CosmeticSalon.Application.Commands;
using CosmeticSalon.Domain.Entities;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    public async Task HandleAsync(SignUp command)
    {
        // Validate input

        // Validate if user exists( email or username)

        // Create User
        var user = new UserEntity(command.UserId, command.Username, command.Email, command.Password, command.FirstName, command.LastName, command.Role);

        // Save to DB
    }
}
