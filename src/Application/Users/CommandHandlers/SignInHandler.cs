namespace CosmeticSalon.Application.Users.CommandHandlers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.Exceptions;
using CosmeticSalon.Application.Users.Interfaces;
using CosmeticSalon.Domain.Interfaces;

internal sealed class SignInHandler : IRequestHandler<SignIn>
{
    private readonly IAuthService authService;
    private readonly ILogger<SignInHandler> logger;
    private readonly IUserService userService;

    public SignInHandler(IAuthService authService, ILogger<SignInHandler> logger, IUserService userService)
    {
        this.authService = authService;
        this.logger = logger;
        this.userService = userService;
    }

    public async Task Handle(SignIn request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to sign in");

        var user = await this.userService.GetUserByNameAsync(request.Username, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.Username);
        }

        await this.authService.SignInAsync(request, cancellationToken);
    }
}
