using AutoMapper;
using HCMSapi.DTO;
using HCMSapi.Models;

namespace TodoAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        // SignupDTO = ApplicationUser
        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
            CreateMap<Patient, PatientAndMedicalRecordDto>().ReverseMap();
        }
    }
}
