namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Abstractions;
using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Types;

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

        var userId = new UserId(command.UserId);
        var userRole = "User";

        var user = new UserEntity(userId, command.Username, securedPassword, userRole);

        // Save to DB
    }
}
