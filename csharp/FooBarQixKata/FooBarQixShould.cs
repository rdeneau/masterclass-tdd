using FluentAssertions;
using Xunit;

namespace FooBarQixKata
{
    public class FooBarQixShould
    {
        [Theory]
        [InlineData(1, "1")]
        public void Be_Created(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}