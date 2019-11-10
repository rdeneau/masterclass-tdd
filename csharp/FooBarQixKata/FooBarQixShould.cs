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
            Check(n, expected);

        [Theory]
        [InlineData(9)]
        [InlineData(18)]
        public void Fooify_Multiple_Of_3(int n) =>
            Check(n, "Foo");

        [Theory]
        [InlineData(13)]
        public void Fooify_Number_With_Digit_3(int n) =>
            Check(n, "Foo");

        private static void Check(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}