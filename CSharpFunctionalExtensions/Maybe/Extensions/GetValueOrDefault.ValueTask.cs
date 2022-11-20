#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<T> GetValueOrDefaultAsync<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<T>> defaultValue)
        {
            var maybe = await maybeTask;
            return await maybe.GetValueOrDefaultAsync(defaultValue);
        }
        
        public static async ValueTask<K> GetValueOrDefaultAsync<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> selector,
            K defaultValue = default)
        {
            var maybe = await maybeTask;
            return await maybe.GetValueOrDefaultAsync(selector, defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefaultAsync<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> selector,
            Func<ValueTask<K>> defaultValue)
        {
            var maybe = await maybeTask;
            return await maybe.GetValueOrDefaultAsync(selector, defaultValue);
        }
    }
}
#endif