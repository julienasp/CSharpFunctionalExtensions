﻿using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="action" /> if the <paramref name="maybe" /> has a value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteAsync<T>(this Maybe<T> maybe, Func<T, Task> action)
        {
            if (maybe.HasNoValue)
                return;

            await action(maybe.GetValueOrThrow()).DefaultAwait();
        }
    }
}
