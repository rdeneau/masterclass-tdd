using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static string Of(int n) =>
            Rules.SelectMany(x => x.Matches(n))
                 .DefaultIfEmpty($"{n}".Replace("0", "*"))
                 .JoinToString();

        private static readonly IReadOnlyList<Rule> Rules = new[]
        {
            Rule.MultipleOf(3, "Foo"),
            Rule.MultipleOf(5, "Bar"),
            Rule.MultipleOf(7, "Qix"),
            Rule.WithDigits(('3', "Foo"),
                            ('5', "Bar"),
                            ('7', "Qix"),
                            ('0', "*")),
        };
    }
}