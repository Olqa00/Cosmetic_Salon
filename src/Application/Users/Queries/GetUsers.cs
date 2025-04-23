namespace CosmeticSalon.Application.Users.Queries;

using CosmeticSalon.Application.Users.ViewModels;

public sealed class GetUsers : IRequest<IReadOnlyList<User>>
{
}
