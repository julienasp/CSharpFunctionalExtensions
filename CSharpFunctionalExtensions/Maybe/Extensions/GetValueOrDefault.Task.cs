using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<T> GetValueOrDefaultAsync<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefaultAsync(defaultValue).DefaultAwait();
        }
        
        public static async Task<K> GetValueOrDefaultAsync<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefaultAsync(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefaultAsync<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefaultAsync(selector, defaultValue).DefaultAwait();
        }
    }
}
