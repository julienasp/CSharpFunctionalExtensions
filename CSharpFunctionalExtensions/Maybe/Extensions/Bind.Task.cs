﻿using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> BindAsync<T, K>(this Task<Maybe<T>> maybeTask,
            Func<T, Task<Maybe<K>>> selector)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Bind(selector).DefaultAwait();
        }
    }
}
