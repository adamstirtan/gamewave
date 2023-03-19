using System;

using AutoMapper;

using FinalBoss.Api.Dto;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> Configure()
        {
            return config =>
            {
                config.CreateMap<Company, CompanyDto>()
                    .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                    .ReverseMap();

                config.CreateMap<Game, GameDto>()
                    .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DeveloperId, x => x.MapFrom(src => src.Developer.Id))
                    .ReverseMap();

                config.CreateMap<Platform, PlatformDto>()
                    .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                    .ReverseMap();
            };
        }
    }
}