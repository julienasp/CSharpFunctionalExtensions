﻿using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task ExecuteAsync<T>(this Task<Maybe<T>> maybeTask, Func<T, Task> asyncAction)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return;

            await asyncAction(maybe.GetValueOrThrow()).DefaultAwait();
        } 
    }
}
