namespace CosmeticSalon.Application.Users.Interfaces;

using CosmeticSalon.Application.Users.Commands;

public interface IAuthService
{
    Task<bool> SignInAsync(SignIn request, CancellationToken cancellationToken = default);

    //Task SignOutAsync(CancellationToken cancellationToken = default);
    //Task<AuthenticationResponse> SignUpAsync(SignUpRequest signUpRequest, CancellationToken cancellationToken = default);
    //Task<AuthenticationResponse> ChangePasswordAsync(ClaimsPrincipal user, string currentPassword, string newPassword, CancellationToken cancellationToken = default);
    //Task<AuthenticationResponse> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken = default);
    //Task<TokenResponse> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken = default);
    //Task<ApplicationUserDto> GetCurrentUserAsync(ClaimsPrincipal user, CancellationToken cancellationToken = default);
    //Task<TokenResponse> GenerateEmailConfirmationAsync(ClaimsPrincipal user);
    //Task<TokenResponse> GenerateEmailChangeAsync(ClaimsPrincipal user, string newEmail);
    //Task<AuthenticationResponse> ConfirmEmailAsync(EmailConfirmationRequest emailConfirmationRequest);
    //Task RefreshSignInAsync(ClaimsPrincipal user);
}
