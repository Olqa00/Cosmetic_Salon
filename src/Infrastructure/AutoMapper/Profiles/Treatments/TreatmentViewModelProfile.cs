namespace CosmeticSalon.Infrastructure.AutoMapper.Profiles.Treatments;

using global::AutoMapper;
using Add = CosmeticSalon.Application.Commands.AddTreatment;
using ViewModel = CosmeticSalon.Application.ViewModels.Treatment;

internal sealed class TreatmentViewModelProfile : Profile
{
    public TreatmentViewModelProfile()
    {
        this.CreateMap<ViewModel, Add>()
            .ForMember(target => target.Id, options => options.MapFrom(source => source.Id))
            .ForMember(target => target.Name, options => options.MapFrom(source => source.Name))
            .ForMember(target => target.Type, options => options.MapFrom(source => source.Type))
            ;
    }
}
