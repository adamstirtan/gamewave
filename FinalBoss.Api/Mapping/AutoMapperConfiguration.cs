using System;

using AutoMapper;

namespace FinalBoss.Api.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> Configure()
        {
            return Configure =>
            { };
        }
    }
}