using AutoMapper;
using Journey.Communication.Responses;
using Journey.Infrastructure.Entities;
using System.Collections.Generic;

namespace Journey.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trip, ResponseShortTripJson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));
 
            CreateMap<List<Trip>, List<ResponseShortTripJson>>();

            CreateMap<Trip, ResponseTripJson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate)
                .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities));
            
            CreateMap<List<Trip>, List<ResponseTripJson>>();

            CreateMap<Activity, ResponseActivityJson>();
        }
    }
}
