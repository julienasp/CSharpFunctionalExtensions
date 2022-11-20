using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ExecuteTests : MaybeTestBase
    {
        [Fact]
        public void Execute_does_not_execute_action_if_no_value()
        {
            Maybe<T> instance = null;
            
            instance.Execute(value => instance = T.Value);

            instance.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Execute_executes_action_if_value()
        {
            Maybe<T> instance = T.Value;

            instance.Execute(value => value.Should().Be(T.Value));

            instance.Value.Should().Be(T.Value);
        }

        [Fact]
        public void Execute_returns_func_result()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Map(ExpectAndReturn(T.Value, T.Value2));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value2);
        }

        [Fact]
        public void Execute_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = maybe.Map(ExpectAndReturn(null, T.Value2));

            maybe2.HasValue.Should().BeFalse();
        }
    }
}
