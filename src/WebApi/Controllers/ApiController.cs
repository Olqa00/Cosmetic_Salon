﻿namespace CosmeticSalon.WebApi.Controllers;

public class ApiController : Controller
{
    private ISender? mediator;
    protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>()!;
}