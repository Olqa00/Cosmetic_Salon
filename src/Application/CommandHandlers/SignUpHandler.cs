namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Abstractions;
using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager passwordManager;

    public SignUpHandler(IPasswordManager passwordManager)
    {
        this.passwordManager = passwordManager;
    }

    public async Task HandleAsync(SignUp command)
    {
        // Validate input

        // Validate if user exists( email or username)

        // Create User
        var securedPassword = this.passwordManager.Secure(command.Password);

        var user = new UserEntity(command.UserId, command.Username, command.Email, securedPassword, command.FirstName, command.LastName, command.Role);

        // Save to DB
    }
}
