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
                    .ForMember(dest => dest.Created, x => x.MapFrom(src => src.Created))
                    .ForMember(dest => dest.LastModified, x => x.MapFrom(src => src.LastModified))
                    .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, x => x.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Slug, x => x.MapFrom(src => src.Slug))
                    .ForMember(dest => dest.ImageUrl, x => x.MapFrom(src => src.ImageUrl))
                    .ForMember(dest => dest.Category, x => x.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Generation, x => x.MapFrom(src => src.Generation))
                    .ReverseMap();

                config.CreateMap<Release, ReleaseDto>()
                    .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Created, x => x.MapFrom(src => src.Created))
                    .ForMember(dest => dest.LastModified, x => x.MapFrom(src => src.LastModified))
                    .ForMember(dest => dest.ReleaseDate, x => x.MapFrom(src => src.ReleaseDate))
                    .ForMember(dest => dest.PlatformId, x => x.MapFrom(src => src.Platform.Id))
                    .ReverseMap();
            };
        }
    }
}