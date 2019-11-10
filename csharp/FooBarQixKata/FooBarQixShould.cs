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
        [InlineData(10)]
        [InlineData(20)]
        public void Barify_Multiple_Of_5(int n) =>
            Check(n, "Bar");

        [Theory]
        [InlineData(13)]
        public void Fooify_Number_With_Digit_3(int n) =>
            Check(n, "Foo");

        [Theory]
        [InlineData(3, "FooFoo", "Multiple of 3, Have Digit 3 one time")]
        [InlineData(15, "FooBarBar", "Multiple of 3 and 5, Have Digit 5 one time")]
        public void Concatenate_Matching_Cases(int n, string expected, string description) =>
            Check(n, expected);

        private static void Check(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}