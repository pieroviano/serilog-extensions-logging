#if NET45

using System.Collections.Generic;

namespace Microsoft.Extensions.Logging
{
    /// <summary>
    /// Class LoggerFilterOptions.
    /// </summary>
    public class LoggerFilterOptions
    {
        /// <summary>
        /// Gets or sets the minimum level of log messages if none of the rules match.
        /// </summary>
        public LogLevel MinLevel { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="T:Microsoft.Extensions.Logging.LoggerFilterRule" /> used for filtering log messages.
        /// </summary>
        public IList<LoggerFilterRule> Rules { get; } = (IList<LoggerFilterRule>)new List<LoggerFilterRule>();
    }
}

#endif