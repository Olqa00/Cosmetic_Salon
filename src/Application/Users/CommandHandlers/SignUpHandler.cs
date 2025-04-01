namespace CosmeticSalon.Application.Users.CommandHandlers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Domain.Interfaces;

internal sealed class SignUpHandler : IRequestHandler<SignUp>
{
    private readonly ILogger<SignUpHandler> logger;
    private readonly IUserService userService;

    public SignUpHandler(ILogger<SignUpHandler> logger, IUserService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    public async Task Handle(SignUp command, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to sign up");

        //var email = new Email(command.Email);
        //var userId = new UserId(command.UserId);

        //await this.userService.CheckEmailExistsAsync(email, cancellationToken);
        //await this.userService.CheckUserIdExistsAsync(userId, cancellationToken);
        //await this.userService.CheckUsernameExistsAsync(command.Username, cancellationToken);

        //var securedPassword = "this.passwordManager.Secure(command.Password)";

        //var userRole = Role.User();

        //var user = new UserEntity(userId, email, command.Username, securedPassword, userRole);

        //await this.userService.CreateUserAsync(user, cancellationToken);
    }
}
