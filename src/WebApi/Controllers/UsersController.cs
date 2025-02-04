namespace CosmeticSalon.WebApi.Controllers;

using CosmeticSalon.Application.Commands;
using CosmeticSalon.WebApi.Models;

[ApiController]
public sealed class UsersController : ApiController
{
    [Route("SignUp")]
    public IActionResult SignUpView()
    {
        return this.View();
    }

    [HttpPost, Route("SignUp")]
    public async Task<IActionResult> SignUpView([FromForm] SignUpUser user)
    {
        if (this.ModelState.IsValid is false)
        {
            return this.View(user);
        }

        var id = Guid.NewGuid();

        var command = new SignUp
        {
            Email = user.Email,
            Password = user.Password,
            UserId = id,
            Username = user.Username,
        };

        await this.Mediator.Send(command);

        return this.RedirectToPage("Index");
    }
}
