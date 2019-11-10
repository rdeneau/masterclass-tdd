using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static string Of(int n) =>
            Cases()
                .Where(x => x.Match(n))
                .Select(x => x.Value)
                .DefaultIfEmpty($"{n}")
                .JoinToString();

        private static IEnumerable<Case> Cases()
        {
            yield return Case.MultipleOf3;
            yield return Case.MultipleOf5;

            yield return Case.WithDigit3;
            yield return Case.WithDigit5;
        }
    }

    public class Case
    {
        public static readonly Case MultipleOf3 = new Case("Foo", n => n.IsMultipleOf(3));
        public static readonly Case MultipleOf5 = new Case("Bar", n => n.IsMultipleOf(5));

        public static readonly Case WithDigit3 = new Case("Foo", n => $"{n}".Contains("3"));
        public static readonly Case WithDigit5 = new Case("Bar", n => $"{n}".Contains("5"));

        public Func<int, bool> Match { get; }

        public string Value { get; }

        private Case(string value, Func<int, bool> match)
        {
            Match = match;
            Value = value;
        }
    }
}