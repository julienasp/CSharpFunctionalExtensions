﻿using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Result<T>> ToResultAsync<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToResult(errorMessage);
        }

        public static async Task<Result<T, E>> ToResultAsync<T, E>(this Task<Maybe<T>> maybeTask, E error)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToResult(error);
        }
    }
}
