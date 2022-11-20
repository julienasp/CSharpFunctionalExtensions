﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class WhereTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task Where_Task_returns_value_if_predicate_returns_true()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsTask().WhereAsync(ExpectAndReturn_Task(T.Value, true));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task Where_Task_returns_no_value_if_predicate_returns_false()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsTask().WhereAsync(ExpectAndReturn_Task(T.Value, false));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Where_Task_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.AsTask().WhereAsync(ExpectAndReturn_Task(null, predicateResult));

            maybe2.HasValue.Should().BeFalse();
        }
    }
}