namespace CosmeticSalon.Infrastructure.Identity.QueryHandlers;

using CosmeticSalon.Application.Users.Queries;
using CosmeticSalon.Application.Users.ViewModels;
using CosmeticSalon.Domain.Interfaces;
using global::AutoMapper;

internal sealed class GetUsersHandler : IRequestHandler<GetUsers, IReadOnlyList<User>>
{
    private readonly ILogger<GetUsersHandler> logger;
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public GetUsersHandler(ILogger<GetUsersHandler> logger, IMapper mapper, IUserService userService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.userService = userService;
    }

    public async Task<IReadOnlyList<User>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Try to get users");

        var userEntities = await this.userService.GetUsersAsync(cancellationToken);

        var users = this.mapper.Map<IReadOnlyList<User>>(userEntities);

        return users;
    }
}
