﻿namespace CosmeticSalon.Infrastructure.AutoMapper.Profiles.Users;

using global::AutoMapper;
using SignUp = CosmeticSalon.Application.Users.Commands.SignUp;
using SignUpViewModel = CosmeticSalon.Application.Users.ViewModels.SignUpUser;
using SingIn = CosmeticSalon.Application.Users.Commands.SignIn;
using SingInViewModel = CosmeticSalon.Application.Users.ViewModels.SignInUser;

internal sealed class UserViewModelProfile : Profile
{
    public UserViewModelProfile()
    {
        this.CreateMap<SignUpViewModel, SignUp>()
            .ForMember(target => target.Email, options => options.MapFrom(source => source.Email))
            .ForMember(target => target.Password, options => options.MapFrom(source => source.Password))
            .ForMember(target => target.Username, options => options.MapFrom(source => source.Username))
            .ForMember(target => target.UserId, options => options.MapFrom(source => source.Id))
            ;

        this.CreateMap<SingInViewModel, SingIn>()
            .ForMember(target => target.Password, options => options.MapFrom(source => source.Password))
            .ForMember(target => target.Username, options => options.MapFrom(source => source.Username))
            ;
    }
}
