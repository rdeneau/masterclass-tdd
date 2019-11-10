using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBarQixKata
{
    public class Rule
    {
        public static Rule MultipleOf(int p, string then) => new Rule(
            n => n.IsMultipleOf(p)
                     ? new[] {then}
                     : new string[0]);

        public static Rule WithDigits(params (char c, string then)[] digits) => new Rule(
            n => n.ToString("0")
                  .ToCharArray()
                  .Select(c => digits.Where(x => x.c == c)
                                     .Select(x => x.then)
                                     .FirstOrDefault())
                  .Where(x => x != null));

        public Func<int, IEnumerable<string>> Matches { get; }

        private Rule(Func<int, IEnumerable<string>> matches)
        {
            Matches = matches;
        }
    }
}