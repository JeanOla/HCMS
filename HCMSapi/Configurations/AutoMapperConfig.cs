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

            CreateMap<Cases, addPatientCaseDTO>().ReverseMap()
            .ForMember(f => f.patientId, t2 => t2.MapFrom(src => src.patientId));
            CreateMap<Patient, PatientAndMedicalRecordDto>().ReverseMap();

            CreateMap<AddDoctorScheduleDTO, Schedule>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.doctorId, opt => opt.MapFrom(src => src.doctorId))
            .ForMember(dest => dest.User, opt => opt.Ignore()) 
            .ForMember(dest => dest.dayOfWeek, opt => opt.MapFrom(src => src.dayOfWeek))
            .ForMember(dest => dest.startTime, opt => opt.MapFrom(src => src.startTime))
            .ForMember(dest => dest.endTime, opt => opt.MapFrom(src => src.endTime));


            CreateMap<Cases, UpdateCasaeDTO>().ReverseMap()
          .ForMember(f => f.patientId, t2 => t2.MapFrom(src => src.patientId));
            CreateMap<Patient, PatientAndMedicalRecordDto>().ReverseMap();
        }
    }
}
