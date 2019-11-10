using System;
using System.Linq;

namespace FooBarQixKata
{
    public class Rule
    {
        public static Rule MultipleOf(int p, string then) =>
            new Rule(
                n => n.IsMultipleOf(p),
                _ => then);

        public static Rule WithDigits(params (char c, string then)[] digits) =>
            new Rule(
                n => true,
                n => $"{n}"
                     .ToCharArray()
                     .Select(c => digits.Where(x => x.c == c)
                                        .Select(x => x.then)
                                        .FirstOrDefault())
                     .Where(x => x != null)
                     .JoinToString());

        public Func<int, bool> Match { get; }

        public Func<int, string> Replace { get; }

        private Rule(Func<int, bool> match, Func<int, string> replace)
        {
            Match   = match;
            Replace = replace;
        }
    }
}