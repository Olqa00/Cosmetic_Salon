namespace CosmeticSalon.Infrastructure.Identity.Services;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class AuthService : IAuthService
{
    private readonly ILogger<AuthService> logger;
    private readonly SignInManager<UserDbModel> signInManager;

    public AuthService(ILogger<AuthService> logger, SignInManager<UserDbModel> signInManager)
    {
        this.logger = logger;
        this.signInManager = signInManager;
    }

    public async Task<bool> SignInAsync(SignIn request, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Try to sign in using service");
        var signInResult = await this.signInManager.PasswordSignInAsync(request.Username, request.Password, request.RememberMe, lockoutOnFailure: false);

        return signInResult.Succeeded;
    }
}
