using FluentAssertions;
using Xunit;

namespace FooBarQixKata
{
    public class FooBarQixShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        public void Stringify_Other_Numbers(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}