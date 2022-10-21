#if NET45 || NET40
namespace System.Threading
{
    /// <summary>Represents ambient data that is local to a given asynchronous control flow, such as an asynchronous method.</summary>
    /// <typeparam name="T">The type of the ambient data.</typeparam>
    public sealed class AsyncLocal<T>
    {
        /// <summary>Instantiates an <see cref="T:System.Threading.AsyncLocal`1"></see> instance that does not receive change notifications.</summary>
        public AsyncLocal(){}

        /// <summary>Instantiates an <see cref="T:System.Threading.AsyncLocal`1"></see> local instance that receives change notifications.</summary>
        /// <param name="valueChangedHandler">The delegate that is called whenever the current value changes on any thread.</param>
        public AsyncLocal(
            Action<AsyncLocalValueChangedArgs<T>> valueChangedHandler)
        {
        }

        /// <summary>Gets or sets the value of the ambient data.</summary>
        /// <returns>The value of the ambient data.</returns>
        public T Value { get; set; }
    }
}
#endif