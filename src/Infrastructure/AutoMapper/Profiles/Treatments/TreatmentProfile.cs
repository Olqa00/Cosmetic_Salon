namespace CosmeticSalon.Infrastructure.AutoMapper.Profiles.Treatments;

using global::AutoMapper;
using Model = CosmeticSalon.Domain.Entities.TreatmentEntity;
using ViewModel = CosmeticSalon.Application.ViewModels.Treatment;

internal sealed class TreatmentProfile : Profile
{
    public TreatmentProfile()
    {
        this.CreateMap<Model, ViewModel>()
            .ForMember(target => target.Id, options => options.MapFrom(source => source.Id.Value))
            .ForMember(target => target.Name, options => options.MapFrom(source => source.Name))
            .ForMember(target => target.Type, options => options.MapFrom(source => source.Type))
            ;
    }
}
