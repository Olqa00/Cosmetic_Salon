namespace CosmeticSalon.Application.Treatments.CommandHandlers;

using CosmeticSalon.Application.Common.Extensions;
using CosmeticSalon.Application.Treatments.Commands;
using CosmeticSalon.Application.Treatments.Exceptions;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;

internal sealed class AddTreatmentHandler : IRequestHandler<AddTreatment>
{
    private readonly ILogger<AddTreatmentHandler> logger;
    private readonly ITreatmentRepository repository;

    public AddTreatmentHandler(ILogger<AddTreatmentHandler> logger, ITreatmentRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task Handle(AddTreatment request, CancellationToken cancellationToken)
    {
        using var loggerScope = this.logger.BeginPropertyScope(
            (nameof(TreatmentId), request.Id)
        );

        this.logger.LogInformation("Try to add treatment");

        var treatmentId = new TreatmentId(request.Id);
        var treatment = await this.repository.GetByIdAsync(treatmentId);

        if (treatment is not null)
        {
            throw new TreatmentAlreadyExistsException(treatmentId);
        }

        var treatmentEntity = new TreatmentEntity(treatmentId, request.Type, request.Name);

        await this.repository.AddTreatmentAsync(treatmentEntity);
    }
}
