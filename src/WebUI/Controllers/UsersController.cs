namespace CosmeticSalon.WebUI.Controllers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.Queries;
using CosmeticSalon.Application.Users.ViewModels;

[ApiController]
public sealed class UsersController : BaseController
{
    private readonly ILogger<UsersController> logger;

    public UsersController(ILogger<UsersController> logger)
    {
        this.logger = logger;
    }

    [Route("SignIn")]
    public IActionResult SignInView(CancellationToken cancellationToken = default)
    {
        return this.View();
    }

    [HttpPost, Route("SignIn"), ValidateAntiForgeryToken]
    public async Task<IActionResult> SignInView([FromForm] SignInUser user, CancellationToken cancellationToken = default)
    {
        if (this.ModelState.IsValid is false)
        {
            return this.View(user);
        }

        try
        {
            var command = this.Mapper.Map<SignIn>(user);
            await this.Mediator.Send(command, cancellationToken);

            return await Task.FromResult(this.RedirectToAction(nameof(this.UsersView)));
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "{Message}", exception.Message);

            return await Task.FromResult(this.View());
        }
    }

    [Route("SignUp")]
    public IActionResult SignUpView(CancellationToken cancellationToken = default)
    {
        return this.View();
    }

    [HttpPost, Route("SignUp"), ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUpView([FromForm] SignUpUser user, CancellationToken cancellationToken = default)
    {
        if (this.ModelState.IsValid is false)
        {
            return this.View(user);
        }

        try
        {
            var id = Guid.NewGuid();
            user = user with { Id = id };

            var command = this.Mapper.Map<SignUp>(user);
            await this.Mediator.Send(command, cancellationToken);

            return await Task.FromResult(this.RedirectToAction(nameof(this.UsersView)));
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "{Message}", exception.Message);

            return await Task.FromResult(this.View());
        }
    }

    [HttpGet, Route("GetUsers")]
    public async Task<IActionResult> UsersView(CancellationToken cancellationToken = default)
    {
        var query = new GetUsers();

        var users = await this.Mediator.Send(query, cancellationToken);

        return await Task.FromResult(this.View(users));
    }
}
