﻿using CommonService.Application.Behaviors;
using CommonService.Application.Interfaces.IServices;
using CommonService.Infrastructure.Services;
using MediatR;
using System.Reflection;

namespace CommonService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // In-Memory Cache
        services.AddMemoryCache();
        services.AddScoped<ICacheService, InMemoryCacheService>();

        // Nếu muốn Redis
        // var redisConnection = config.GetConnectionString("Redis");
        // services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));
        // services.AddScoped<ICacheService, RedisCacheService>();

        return services;
    }
}
