namespace CosmeticSalon.IntegrationTests.DAL.Services;

using System.Reflection;
using CosmeticSalon.Application;
using CosmeticSalon.Application.Treatments.CommandHandlers;
using CosmeticSalon.Application.Treatments.Commands;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.Types;
using CosmeticSalon.Infrastructure;
using CosmeticSalon.Infrastructure.DAL.QueryHandlers;
using CosmeticSalon.Infrastructure.DAL.Services;
using CosmeticSalon.Infrastructure.Identity.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;
using CosmeticSalon.Infrastructure.Identity.Services;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

[TestClass]
public sealed class GetTreatmentsTests
{
    private const string TREATMENT_NAME = "treatment-name";
    private const string TREATMENT_TYPE = "treatment-type";
    private readonly IMediator mediator;
    private readonly ITreatmentRepository repository;
    private readonly UserManager<UserDbModel> userManager;
    private readonly IUserMappingService userMappingService;
    private readonly IUserService userService;

    public GetTreatmentsTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true, reloadOnChange: true)
            .Build();

        var serviceCollection = new ServiceCollection();

        var repositoryLogger = new NullLogger<TreatmentRepository>();
        var addHandlerLogger = new NullLogger<AddTreatmentHandler>();
        var getHandlerLogger = new NullLogger<GetTreatmentsHandler>();
        var userMappingServiceLogger = new NullLogger<UserMappingService>();
        var userServiceLogger = new NullLogger<UserService>();
        var userManagerLogger = new NullLogger<UserManager<UserDbModel>>();
        serviceCollection.AddApplication();
        serviceCollection.AddInfrastructure(configuration);
        serviceCollection.AddSingleton<ILogger<TreatmentRepository>>(repositoryLogger);
        serviceCollection.AddSingleton<ILogger<AddTreatmentHandler>>(addHandlerLogger);
        serviceCollection.AddSingleton<ILogger<GetTreatmentsHandler>>(getHandlerLogger);
        serviceCollection.AddSingleton<ILogger<UserMappingService>>(userMappingServiceLogger);
        serviceCollection.AddSingleton<ILogger<UserService>>(userServiceLogger);
        serviceCollection.AddSingleton<ILogger<UserManager<UserDbModel>>>(userManagerLogger);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        this.mediator = serviceProvider.GetRequiredService<IMediator>();
        this.userManager = serviceProvider.GetRequiredService<UserManager<UserDbModel>>();
        this.userMappingService = serviceProvider.GetRequiredService<IUserMappingService>();
        this.userService = serviceProvider.GetRequiredService<IUserService>();
        this.repository = serviceProvider.GetRequiredService<ITreatmentRepository>();
    }

    [TestMethod]
    public async Task GetTreatmentsAsync_ShouldReturnTreatments()
    {
        // Arrange
        var id = Guid.NewGuid();
        var treatmentId = new TreatmentId(id);

        var command = new AddTreatment
        {
            Id = id,
            Type = TREATMENT_TYPE,
            Name = TREATMENT_NAME,
        };

        await this.mediator.Send(command, CancellationToken.None);
        await Task.Delay(millisecondsDelay: 100, CancellationToken.None);

        // Act
        var treatments = await this.repository.GetTreatmentsAsync();

        // Assert
        treatments.Should()
            .NotBeEmpty()
            .And
            .Contain(treatment => treatment.Id.Value == id)
            ;
    }
}
