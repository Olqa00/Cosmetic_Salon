namespace CosmeticSalon.Application.Users.CommandHandlers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;

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

        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);

        var user = new UserEntity(userId, email, command.Username, command.Password, Role.User());

        await this.userService.RegisterAsync(user, cancellationToken);
    }
}
