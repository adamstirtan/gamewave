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
                config.CreateMap<Game, GameDto>()
                    .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                    .ReverseMap();
            };
        }
    }
}