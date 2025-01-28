namespace CosmeticSalon.Infrastructure.QueryHandlers;

using CosmeticSalon.Application.Queries;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using Microsoft.Extensions.Logging;

internal sealed class GetTreatmentsHandler : IRequestHandler<GetTreatments, IReadOnlyList<TreatmentEntity>>
{
    private readonly ILogger<GetTreatmentsHandler> logger;
    private readonly ITreatmentRepository repository;

    public GetTreatmentsHandler(ILogger<GetTreatmentsHandler> logger, ITreatmentRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> Handle(GetTreatments request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to get treatments");

        var treatments = await this.repository.GetTreatmentsAsync();

        return treatments;
    }
}
