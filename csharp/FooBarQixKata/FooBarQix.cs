using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
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