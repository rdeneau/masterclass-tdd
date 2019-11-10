using System.Collections.Generic;

namespace FooBarQixKata
{
    public static class Extensions
    {
        public static bool IsMultipleOf(this int n, int p) =>
            n % p == 0;

        public static string JoinToString(this IEnumerable<string> @this) =>
            string.Join("", @this);
    }
}