using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static IReadOnlyList<Match> Test(int number) =>
            Matches($"{number}".Length)
                .Where(x => x.Test(number))
                .ToList();

        private static IEnumerable<Match> Matches(int length)
        {
            yield return new MultipleOfMatch("Foo", 3);
            yield return new MultipleOfMatch("Bar", 5);
            yield return new MultipleOfMatch("Qix", 7);

            for (var i = 0; i < length; i++)
            {
                yield return new DigitAtMatch("Foo", 3, i);
                yield return new DigitAtMatch("Bar", 5, i);
                yield return new DigitAtMatch("Qix", 7, i);
                yield return new DigitAtMatch("*", 0, i);
            }
        }

        public static string Of(int number) =>
            Test(number)
                .EmptyIfOnlyDigit0()
                .Select(x => x.Word)
                .DefaultIfEmpty($"{number}".Replace("0", "*"))
                .JoinToString();

        private static IEnumerable<Match> EmptyIfOnlyDigit0(this IReadOnlyList<Match> source) =>
            source.All(x => x is DigitAtMatch y && y.Digit == 0)
                ? Enumerable.Empty<Match>()
                : source;
    }
}