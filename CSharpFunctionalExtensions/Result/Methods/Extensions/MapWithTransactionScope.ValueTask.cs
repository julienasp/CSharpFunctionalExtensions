#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result<K>> MapWithTransactionScope<T, K>(this ValueTask<Result<T>> self, Func<T, ValueTask<K>> f)
            => WithTransactionScope(() => self.MapAsync(f));

        public static ValueTask<Result<K>> MapWithTransactionScope<K>(this ValueTask<Result> self, Func<ValueTask<K>> f)
            => WithTransactionScope(() => self.MapAsync(f));
    }
}
#endif
