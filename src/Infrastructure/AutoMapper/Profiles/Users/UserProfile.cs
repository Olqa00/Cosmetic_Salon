namespace CosmeticSalon.Infrastructure.AutoMapper.Profiles.Users;

using global::AutoMapper;
using Model = CosmeticSalon.Domain.Entities.UserEntity;
using ViewModel = CosmeticSalon.Application.Users.ViewModels.User;

internal sealed class UserProfile : Profile
{
    public UserProfile()
    {
        this.CreateMap<Model, ViewModel>()
            .ForMember(target => target.Fullname, options => options.MapFrom(source => source.FullName))
            .ForMember(target => target.Id, options => options.MapFrom(source => source.Id.Value))
            .ForMember(target => target.Role, options => options.MapFrom(source => source.Role.Value))
            ;
    }
}
