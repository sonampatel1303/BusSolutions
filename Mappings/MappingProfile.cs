using AutoMapper;
using FastX_CaseStudy.DTO;
using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
        CreateMap<bus,BusDTO>().ReverseMap();
        }
    }
}
