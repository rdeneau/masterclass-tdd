using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FooBarQixKata
{
    public static class Extensions
    {
        public static bool Match(this string s, string pattern) =>
            new Regex(pattern).IsMatch(s);

        public static bool IsMultipleOf(this int n, int p) =>
            n % p == 0;

        public static string JoinToString(this IEnumerable<string> @this) =>
            string.Join("", @this);
    }
}