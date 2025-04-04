﻿namespace CosmeticSalon.WebUI.Controllers;

using CosmeticSalon.Application.Users.Commands;
using CosmeticSalon.Application.Users.ViewModels;

[ApiController]
public sealed class UsersController : BaseController
{
    private readonly ILogger<UsersController> logger;

    public UsersController(ILogger<UsersController> logger)
    {
        this.logger = logger;
    }

    [Route("SignUp")]
    public IActionResult SignUpView(CancellationToken cancellationToken = default)
    {
        return this.View();
    }

    [HttpPost, Route("SignUp")]
    public async Task<IActionResult> SignUpView([FromForm] SignUpUser user, CancellationToken cancellationToken = default)
    {
        try
        {
            var id = Guid.NewGuid();
            user = user with { Id = id };

            var command = this.Mapper.Map<SignUp>(user);
            await this.Mediator.Send(command, cancellationToken);

            return await Task.FromResult(this.RedirectToPage("Index"));
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "{Message}", exception.Message);

            return await Task.FromResult(this.View());
        }
    }
}
