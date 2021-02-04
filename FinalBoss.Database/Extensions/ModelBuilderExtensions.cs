using System;
using System.Linq;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using FinalBoss.Database.Mappings;

namespace FinalBoss.Database.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder builder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));

            foreach (var configuration in mappingTypes
                .Select(Activator.CreateInstance)
                .Cast<IEntityMappingConfiguration>())
            {
                configuration.Map(builder);
            }
        }
    }
}