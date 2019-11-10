using FluentAssertions;
using FluentAssertions.Primitives;
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
            Check(n, expected);

        [Theory]
        [InlineData(9, "Foo")]
        public void Fooify_Multiple_Of_3(int n, string expected) =>
            Check(n, expected);

        private static void Check(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}