namespace CosmeticSalon.Infrastructure.QueryHandlers;

using CosmeticSalon.Application.Queries;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;
using MediatR;

internal sealed class GetTreatmentsHandler : IRequestHandler<GetTreatments, IReadOnlyList<TreatmentEntity>>
{
    private readonly ITreatmentRepository repository;

    public GetTreatmentsHandler(ITreatmentRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IReadOnlyList<TreatmentEntity>> Handle(GetTreatments request, CancellationToken cancellationToken)
    {
        var treatments = await this.repository.GetTreatmentsAsync();

        return treatments;
    }
}
