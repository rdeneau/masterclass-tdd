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
        public void Barify_Multiple_Of_5_With_Digit_0(int n) =>
            Check(n, "Bar*");

        [Theory]
        [InlineData(14)]
        [InlineData(28)]
        public void Qixify_Multiple_Of_7(int n) =>
            Check(n, "Qix");

        [Theory]
        [InlineData(13)]
        public void Fooify_Number_With_Digit_3(int n) =>
            Check(n, "Foo");

        [Theory]
        [InlineData(3, "FooFoo", "Multiple of 3, Have digit 3")]
        [InlineData(15, "FooBarBar", "Multiple of 3 and 5, Have digit 5")]
        [InlineData(33, "FooFooFoo", "Multiple of 3, Have digits 3, 3")]
        [InlineData(21, "FooQix", "Multiple of 3 and 7")]
        [InlineData(37, "FooQix", "Have digits 3, 7")]
        [InlineData(73, "QixFoo", "Have digits 7, 3")]
        public void Concatenate_Matching_Cases(int n, string expected, string description) =>
            Check(n, expected);

        [Theory]
        [InlineData(101, "1*1")]
        [InlineData(303, "FooFoo*Foo")]
        public void Starify_Digit_0_In_Number(int n, string expected) =>
            Check(n, expected);

        private static void Check(int n, string expected) =>
            FooBarQix.Of(n)
                     .Should()
                     .Be(expected);
    }
}