namespace CosmeticSalon.Application.Queries;

using CosmeticSalon.Domain.Entities;

public sealed class GetTreatments : IRequest<IReadOnlyList<TreatmentEntity>>
{
}
