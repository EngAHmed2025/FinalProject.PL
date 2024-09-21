using AutoMapper;
using FinalProject.DAL.Models;
using FinalProject.PL.Models;

namespace FinalProject.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();/*.ForMember(d => d.Name, o => o.MapFrom(S => S.Name));*/
        }
    }
}
