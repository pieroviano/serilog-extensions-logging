#if NET45

using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>Implementation of IConfigureNamedOptions.</summary>
    /// <typeparam name="TOptions"></typeparam>
    public class ConfigureNamedOptions<TOptions> :
        IConfigureNamedOptions<TOptions>,
        IConfigureOptions<TOptions>
        where TOptions : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureNamedOptions{TOptions}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="action">The action.</param>
        public ConfigureNamedOptions(string name, System.Action<TOptions> action)
        {
            this.Name = name;
            this.Action = action;
        }

        /// <summary>The options name.</summary>
        public string Name { get; }

        /// <summary>The configuration action.</summary>
        public System.Action<TOptions> Action { get; }

        /// <summary>
        /// Invokes the registered configure Action if the name matches.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public virtual void Configure(string name, TOptions options)
        {
            if ((object)options == null)
                throw new ArgumentNullException(nameof(options));
            if (this.Name != null && !(name == this.Name))
                return;
            System.Action<TOptions> action = this.Action;
            if (action == null)
                return;
            action(options);
        }

        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(TOptions options) => this.Configure(string.Empty, options);
    }
}

#endif