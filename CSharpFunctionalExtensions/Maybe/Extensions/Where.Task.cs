﻿using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<T>> WhereAsync<T>(this Task<Maybe<T>> maybeTask, Func<T, Task<bool>> predicate)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.WhereAsync(predicate).DefaultAwait();
        }
    }
}
