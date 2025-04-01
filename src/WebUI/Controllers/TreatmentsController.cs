namespace CosmeticSalon.WebUI.Controllers;

using CosmeticSalon.Application.Treatments.Commands;
using CosmeticSalon.Application.Treatments.Queries;
using CosmeticSalon.Application.Treatments.ViewModels;

[ApiController]
public sealed class TreatmentsController : BaseController
{
    private readonly ILogger<TreatmentsController> logger;

    public TreatmentsController(ILogger<TreatmentsController> logger)
    {
        this.logger = logger;
    }

    [Route("AddTreatment")]
    public IActionResult AddTreatmentView(CancellationToken cancellationToken = default)
    {
        return this.View();
    }

    [HttpPost, Route("AddTreatment"), ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTreatmentView([FromForm] Treatment treatment, CancellationToken cancellationToken = default)
    {
        try
        {
            var id = Guid.NewGuid();

            treatment = treatment with { Id = id };

            var command = this.Mapper.Map<AddTreatment>(treatment);
            await this.Mediator.Send(command, cancellationToken);

            return await Task.FromResult(this.RedirectToAction(nameof(this.TreatmentsView)));
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "{Message}", exception.Message);

            return await Task.FromResult(this.View());
        }
    }

    [HttpGet, Route("GetTreatments")]
    public async Task<IActionResult> TreatmentsView(CancellationToken cancellationToken = default)
    {
        var query = new GetTreatments();

        var treatments = await this.Mediator.Send(query, cancellationToken);

        return await Task.FromResult(this.View(treatments));
    }
}
