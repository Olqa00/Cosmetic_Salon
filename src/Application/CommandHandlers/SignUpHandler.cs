namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;

internal sealed class SignUpHandler : IRequestHandler<SignUp>
{
    private readonly ILogger<SignUpHandler> logger;
    private readonly IPasswordManager passwordManager;

    public SignUpHandler(ILogger<SignUpHandler> logger, IPasswordManager passwordManager)
    {
        this.logger = logger;
        this.passwordManager = passwordManager;
    }

    public async Task Handle(SignUp command, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to sign up");

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
