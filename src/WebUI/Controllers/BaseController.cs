namespace CosmeticSalon.WebUI.Controllers;

using AutoMapper;

public class BaseController : Controller
{
    private IMapper? mapper;
    private ISender? mediator;
    protected IMapper Mapper => this.mapper ??= this.HttpContext.RequestServices.GetService<IMapper>()!;
    protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>()!;
}
