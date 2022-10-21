#if NET45 || NET40

using System;

namespace Microsoft.Extensions.Logging
{
    /// <summary>Defines a rule used to filter log messages</summary>
    public class LoggerFilterRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerFilterRule"/> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="filter">The filter.</param>
        public LoggerFilterRule(
          string providerName,
          string categoryName,
          Microsoft.Extensions.Logging.LogLevel? logLevel,
          Func<string, string, Microsoft.Extensions.Logging.LogLevel, bool> filter)
        {
            this.ProviderName = providerName;
            this.CategoryName = categoryName;
            this.LogLevel = logLevel;
            this.Filter = filter;
        }

        /// <summary>
        /// Gets the logger provider type or alias this rule applies to.
        /// </summary>
        public string ProviderName { get; }

        /// <summary>Gets the logger category this rule applies to.</summary>
        public string CategoryName { get; }

        /// <summary>
        /// Gets the minimum <see cref="P:Microsoft.Extensions.Logging.LoggerFilterRule.LogLevel" /> of messages.
        /// </summary>
        public Microsoft.Extensions.Logging.LogLevel? LogLevel { get; }

        /// <summary>
        /// Gets the filter delegate that would be applied to messages that passed the <see cref="P:Microsoft.Extensions.Logging.LoggerFilterRule.LogLevel" />.
        /// </summary>
        public Func<string, string, Microsoft.Extensions.Logging.LogLevel, bool> Filter { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => string.Format("{0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}'", (object)"ProviderName", (object)this.ProviderName, (object)"CategoryName", (object)this.CategoryName, (object)"LogLevel", (object)this.LogLevel, (object)"Filter", (object)this.Filter);
    }
}
#endif