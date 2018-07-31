﻿using Microsoft.Extensions.DependencyInjection;

using Modix.Data.Repositories;

namespace Modix.Services.Moderation
{
    /// <summary>
    /// Contains extension methods for configuring the Moderation feature, upon application startup.
    /// </summary>
    public static class ModerationSetup
    {
        /// <summary>
        /// Adds the services and classes that make up the Moderation feature, to a service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the Moderation services are to be added.</param>
        /// <returns><paramref name="services"/></returns>
        public static IServiceCollection AddModixModeration(this IServiceCollection services)
            => services
                .AddSingleton<IBehavior, ModerationAutoConfigBehavior>()
                .AddSingleton<ModerationAutoRescindBehavior>()
                .AddSingleton<IBehavior>(serviceProvider => serviceProvider.GetRequiredService<ModerationAutoRescindBehavior>())
                .AddSingleton<IInfractionEventHandler>(serviceProvider => serviceProvider.GetRequiredService<ModerationAutoRescindBehavior>())
                .AddScoped<IModerationService, ModerationService>()
                .AddScoped<IModerationMuteRoleMappingRepository, ModerationMuteRoleMappingRepository>()
                .AddScoped<IModerationLogChannelMappingRepository, ModerationLogChannelMappingRepository>()
                .AddScoped<IModerationActionRepository, ModerationActionRepository>()
                .AddScoped<IInfractionRepository, InfractionRepository>();
    }
}