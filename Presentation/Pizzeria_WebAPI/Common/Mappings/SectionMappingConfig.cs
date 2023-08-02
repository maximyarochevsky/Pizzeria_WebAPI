using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Sections.Queries.ViewModels;
using Pizzeria.Contracts.Section.Get;

namespace Pizzeria_WebAPI.Common.Mappings;

public class SectionMappingConfig : IMapWith<SectionVm>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SectionVm, GetSectionByIdResponse>()
            .ForMember(sectionVm => sectionVm.Name,
                opt => opt.MapFrom(section => section.Name));


        profile.CreateMap<ListSectionsVm, GetSectionListResponse>()
            .ForMember(sectionsResponse => sectionsResponse.Sections,
                opt => opt.MapFrom(sectionsVm => sectionsVm.ListSections));
    }
}
