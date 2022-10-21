#if NET45 || NET40

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represents something that configures the TOptions type.
    /// Note: These are run before all <see cref="T:Microsoft.Extensions.Options.IPostConfigureOptions`1" />.
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    public interface IConfigureOptions<in TOptions> where TOptions : class
    {
        /// <summary>Invoked to configure a TOptions instance.</summary>
        /// <param name="options">The options instance to configure.</param>
        void Configure(TOptions options);
    }
}

#endif