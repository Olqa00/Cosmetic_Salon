namespace CosmeticSalon.Application.Commands;

internal sealed record class AddTreatment : IRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Type { get; init; }
}
