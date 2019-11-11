using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static IEnumerable<Match> Test(int number) =>
            Matches($"{number}".Length)
                .Where(x => x.Test(number));

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
            }
        }

        public static string Of(int n)
        {
            var multiples  = MultipleOfRules.Where(x => x.Match(n)).ToList();
            var isMultiple = multiples.Count > 0;
            var hasDigits  = $"{n}".Match("[357]");

            var rulesToApply = multiples.ToList();
            if (hasDigits || isMultiple)
            {
                rulesToApply.Add(WithDigitsRule);
            }

            return rulesToApply
                   .Select(x => x.Replace(n))
                   .DefaultIfEmpty($"{n}".Replace("0", "*"))
                   .JoinToString();
        }

        private static readonly IReadOnlyList<Rule> MultipleOfRules =
            new[]
            {
                Rule.MultipleOf(3, "Foo"),
                Rule.MultipleOf(5, "Bar"),
                Rule.MultipleOf(7, "Qix"),
            };

        private static readonly Rule WithDigitsRule = Rule.WithDigits(
            ('3', "Foo"),
            ('5', "Bar"),
            ('7', "Qix"),
            ('0', "*"));
    }
}