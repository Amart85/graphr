﻿using Graphr.Neo4j.Configuration;
using Graphr.Neo4j.Driver;
using Graphr.Neo4j.Graphr;
using Graphr.Neo4j.Logging;
using Graphr.Neo4j.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using INeoLogger = Neo4j.Driver.ILogger;

namespace Graphr.Neo4j.DependencyInjection
{
    public static class NeoDependencyInjectionExtensions
    {
        public static IServiceCollection AddNeoGraphr(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NeoDriverConfigurationSettings>(configuration.GetSection(nameof(NeoDriverConfigurationSettings)));

            services
                .AddSingleton<INeoLogger, NeoLogger>()
                .AddSingleton<IDriverProvider, DriverProvider>()
                .AddTransient<IQueryExecutor, QueryExecutor>()
                .AddTransient<INeoGraphr, NeoGraphr>();

            return services;
        }
    }
}