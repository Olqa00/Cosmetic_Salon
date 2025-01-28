namespace CosmeticSalon.WebApi.Controllers;

using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Queries;
using CosmeticSalon.WebApi.Models;

[ApiController]
public sealed class TreatmentsController : ApiController
{
    [Route("AddTreatment")]
    public IActionResult AddTreatmentView()
    {
        return this.View();
    }

    [HttpPost, Route("AddTreatment")]
    public async Task<IActionResult> AddTreatmentView([FromForm] Treatment treatment)
    {
        if (this.ModelState.IsValid is false)
        {
            return this.View(treatment);
        }

        var id = Guid.NewGuid();

        var command = new AddTreatment
        {
            Id = id,
            Name = treatment.Name,
            Type = treatment.Type,
        };

        await this.Mediator.Send(command);

        return this.RedirectToAction(nameof(this.TreatmentsView));
    }

    [HttpGet, Route("GetTreatments")]
    public async Task<IActionResult> TreatmentsView()
    {
        var query = new GetTreatments();

        var treatmentsEntities = await this.Mediator.Send(query);

        var treatments = treatmentsEntities.Select(treatment => new Treatment
        {
            Id = treatment.Id.Value,
            Name = treatment.Name,
            Type = treatment.Type,
        }).ToList();

        return this.View(treatments);
    }
}
