using AutoMapper;
using SkyEuropeJobs.Application.DTOs;
using SkyEuropeJobs.Core.Entities;

namespace SkyEuropeJobs.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
