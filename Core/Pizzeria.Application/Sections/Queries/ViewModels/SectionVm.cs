using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Sections.Queries.ViewModels;

public class SectionVm : IMapWith<Section>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Section, SectionVm>()
            .ForMember(sectionVm => sectionVm.Name,
                opt => opt.MapFrom(section => section.Name));
    }
}

