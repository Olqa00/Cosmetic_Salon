namespace CosmeticSalon.WebApi.Controllers;

using CosmeticSalon.Application.Queries;
using CosmeticSalon.WebApi.Models;

[ApiController]
public sealed class TreatmentsController : ApiController
{
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
