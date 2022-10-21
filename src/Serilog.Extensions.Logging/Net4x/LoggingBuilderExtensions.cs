#if NET45

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Logging
{
    /// <summary>
    ///     Extension methods for setting up logging services in an
    ///     <see cref="T:Microsoft.Extensions.Logging.ILoggingBuilder" />.
    /// </summary>
    public static class LoggingBuilderExtensions
    {
        /// <summary>
        ///     Adds the filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="category">The category.</param>
        /// <param name="level">The level.</param>
        /// <returns>ILoggingBuilder.</returns>
        public static ILoggingBuilder AddFilter<T>(
            this ILoggingBuilder builder,
            string category,
            LogLevel level)
            where T : ILoggerProvider
        {
            return builder.ConfigureFilter(options => options.AddFilter<T>(category, level));
        }

        /// <summary>
        ///     Adds the filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="category">The category.</param>
        /// <param name="level">The level.</param>
        /// <returns>LoggerFilterOptions.</returns>
        public static LoggerFilterOptions AddFilter<T>(
            this LoggerFilterOptions builder,
            string category,
            LogLevel level)
            where T : ILoggerProvider
        {
            return AddRule(builder, typeof(T).FullName, category, level);
        }

        /// <summary>
        ///     Adds the provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>ILoggingBuilder.</returns>
        public static ILoggingBuilder AddProvider(
            this ILoggingBuilder builder,
            ILoggerProvider provider)
        {
            builder.Services.AddSingleton(provider);
            return builder;
        }

        /// <summary>
        ///     Clears the providers.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>ILoggingBuilder.</returns>
        public static ILoggingBuilder ClearProviders(this ILoggingBuilder builder)
        {
            foreach (var loggerProvider in builder.Services)
            {
                if (loggerProvider.ServiceType is ILoggerProvider)
                {
                    builder.Services.Remove(loggerProvider);
                }
            }

            return builder;
        }

        private static LoggerFilterOptions AddRule(
            LoggerFilterOptions options,
            string type = null,
            string category = null,
            LogLevel? level = null,
            Func<string, string, LogLevel, bool> filter = null)
        {
            options.Rules.Add(new LoggerFilterRule(type, category, level, filter));
            return options;
        }

        private static ILoggingBuilder ConfigureFilter(
            this ILoggingBuilder builder,
            Action<LoggerFilterOptions> configureOptions)
        {
            builder.Services.Configure<LoggerFilterOptions>(configureOptions);
            return builder;
        }

        /// <summary>
        /// Configures the specified configure options.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection Configure<TOptions>(
            this IServiceCollection services,
            Action<TOptions> configureOptions)
            where TOptions : class
        {
            return services.Configure<TOptions>(DefaultName, configureOptions);
        }

        /// <summary>
        /// Configures the specified name.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>IServiceCollection.</returns>
        /// <exception cref="System.ArgumentNullException">services</exception>
        /// <exception cref="System.ArgumentNullException">configureOptions</exception>
        public static IServiceCollection Configure<TOptions>(
            this IServiceCollection services,
            string name,
            Action<TOptions> configureOptions)
            where TOptions : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (configureOptions == null)
                throw new ArgumentNullException(nameof(configureOptions));
            services.AddSingleton<IConfigureOptions<TOptions>>((IConfigureOptions<TOptions>)new ConfigureNamedOptions<TOptions>(name, configureOptions));
            return services;
        }

        /// <summary>
        /// The default name
        /// </summary>
        public static readonly string DefaultName = string.Empty;

    }
}

#endif