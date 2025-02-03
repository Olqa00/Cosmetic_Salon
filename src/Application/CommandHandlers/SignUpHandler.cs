namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Exceptions;
using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.ValueObjects;

internal sealed class SignUpHandler : IRequestHandler<SignUp>
{
    private readonly ILogger<SignUpHandler> logger;
    private readonly IPasswordManager passwordManager;
    private readonly IUserRepository userRepository;

    public SignUpHandler(ILogger<SignUpHandler> logger, IPasswordManager passwordManager, IUserRepository userRepository)
    {
        this.logger = logger;
        this.passwordManager = passwordManager;
        this.userRepository = userRepository;
    }

    public async Task Handle(SignUp command, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to sign up");

        var email = new Email(command.Email);
        var emailExists = await this.userRepository.GetByEmailAsync(email);

        if (emailExists is not null)
        {
            throw new EmailAlreadyExistsException(email);
        }

        var usernameExists = await this.userRepository.GetByUsernameAsync(command.Username);

        if (usernameExists is not null)
        {
            throw new UsernameAlreadyExistsException(command.Username);
        }

        var securedPassword = this.passwordManager.Secure(command.Password);

        var userId = new UserId(command.UserId);
        var userRole = Role.User();

        var user = new UserEntity(userId, email, command.Username, securedPassword, userRole);

        await this.userRepository.AddUserAsync(user);
    }
}
