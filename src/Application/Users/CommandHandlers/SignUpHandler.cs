namespace CosmeticSalon.Application.Users.CommandHandlers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.Security;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;

internal sealed class SignUpHandler : IRequestHandler<SignUp>
{
    private readonly ILogger<SignUpHandler> logger;
    private readonly IPasswordManager passwordManager;
    private readonly IUserService userService;

    public SignUpHandler(ILogger<SignUpHandler> logger, IPasswordManager passwordManager, IUserService userService)
    {
        this.logger = logger;
        this.passwordManager = passwordManager;
        this.userService = userService;
    }

    public async Task Handle(SignUp command, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to sign up");

        var email = new Email(command.Email);
        var userId = new UserId(command.UserId);

        await this.userService.CheckEmailExistsAsync(email, cancellationToken);
        await this.userService.CheckUserIdExistsAsync(userId, cancellationToken);
        await this.userService.CheckUsernameExistsAsync(command.Username, cancellationToken);

        var securedPassword = this.passwordManager.Secure(command.Password);

        var userRole = Role.User();

        var user = new UserEntity(userId, email, command.Username, securedPassword, userRole);

        await this.userService.CreateUserAsync(user, cancellationToken);
    }
}
