using System;
using Highway.Data.Interceptors;

namespace Highway.Data
{
    /// <summary>
    /// The standard interface for intercept
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInterceptor<in T> where T : EventArgs
    {
        /// <summary>
        ///  The priority order that this interceptor has for ordered execution by the event manager
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// Executes the interceptor handle an event based on the event arguments
        /// </summary>
        /// <param name="context">The data context that raised the event</param>
        /// <param name="eventArgs">The event arguments that were passed from the context</param>
        /// <returns>An Interceptor Result</returns>
        InterceptorResult Execute(IDataContext context, T eventArgs);
    }
}