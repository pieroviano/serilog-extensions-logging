#if NET45 || NET40

namespace System.Threading
{
    /// <summary>The class that provides data change information to <see cref="T:System.Threading.AsyncLocal`1"></see> instances that register for change notifications.</summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    public struct AsyncLocalValueChangedArgs<T>
    {
        /// <summary>Gets the data's current value.</summary>
        /// <returns>The data's current value.</returns>
        public T CurrentValue { get; }

        /// <summary>Gets the data's previous value.</summary>
        /// <returns>The data's previous value.</returns>
        public T PreviousValue { get; }

        /// <summary>Returns a value that indicates whether the value changes because of a change of execution context.</summary>
        /// <returns>true if the value changed because of a change of execution context; otherwise, false.</returns>
        public bool ThreadContextChanged { get; }
    }
}
#endif