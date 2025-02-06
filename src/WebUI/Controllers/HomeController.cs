namespace CosmeticSalon.WebUI.Controllers;

using System.Diagnostics;
using CosmeticSalon.WebUI.Models;

public sealed class HomeController : ApiController
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }

    public IActionResult Index()
    {
        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }
}
