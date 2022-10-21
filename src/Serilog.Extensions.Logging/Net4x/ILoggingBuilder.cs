﻿#if NET45
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Logging
{
    /// <summary>An interface for configuring logging providers.</summary>
    public interface ILoggingBuilder
    {
        /// <summary>
        /// Gets the <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> where Logging services are configured.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
#endif