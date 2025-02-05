namespace CosmeticSalon.Infrastructure.QueryHandlers;

using CosmeticSalon.Application.Treatments.Queries;
using CosmeticSalon.Application.Treatments.ViewModels;
using CosmeticSalon.Domain.Interfaces;
using global::AutoMapper;

internal sealed class GetTreatmentsHandler : IRequestHandler<GetTreatments, IReadOnlyList<Treatment>>
{
    private readonly ILogger<GetTreatmentsHandler> logger;
    private readonly IMapper mapper;
    private readonly ITreatmentRepository repository;

    public GetTreatmentsHandler(ILogger<GetTreatmentsHandler> logger, IMapper mapper, ITreatmentRepository repository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<IReadOnlyList<Treatment>> Handle(GetTreatments request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to get treatments");

        var treatmentEntities = await this.repository.GetTreatmentsAsync();

        var treatments = this.mapper.Map<IReadOnlyList<Treatment>>(treatmentEntities);

        return treatments;
    }
}
