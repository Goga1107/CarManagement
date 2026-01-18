using AutoMapper;
using CarManagement.Application.Dtos;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceRecord, ServiceRecordDto>();
            CreateMap<User, UserShortDto>();
        }
    }
}
