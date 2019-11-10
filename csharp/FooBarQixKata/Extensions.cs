using System.Collections.Generic;

namespace FooBarQixKata
{
    public static class Extensions
    {
        public static string JoinToString(this IEnumerable<string> @this) =>
            string.Join("", @this);
        
        public static bool IsMultipleOf(this int n, int multiplier) =>
            n % multiplier == 0;
    }
}