using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static string Of(int n) =>
            Cases.SelectMany(x => x.Matches(n))
                 .DefaultIfEmpty($"{n}")
                 .JoinToString();

        private static readonly IReadOnlyList<Case> Cases = new[]
        {
            Case.WhenIsMultipleOf(3, "Foo"),
            Case.WhenIsMultipleOf(5, "Bar"),
            Case.WhenIsMultipleOf(7, "Qix"),

            Case.WhenHasDigit('3', "Foo"),
            Case.WhenHasDigit('5', "Bar"),
            Case.WhenHasDigit('7', "Qix"),
        };
    }

    public class Case
    {
        public static Case WhenIsMultipleOf(int p, string then) => new Case(n =>
            n.IsMultipleOf(p)
                ? new[] { then }
                : new string[0]);

        public static Case WhenHasDigit(char digit, string then) => new Case(n =>
             n.ToString("0")
              .ToCharArray()
              .Where(c => c == digit)
              .Select(c => then));

        public Func<int, IEnumerable<string>> Matches { get; }

        private Case(Func<int, IEnumerable<string>> matches)
        {
            Matches = matches;
        }
    }
}