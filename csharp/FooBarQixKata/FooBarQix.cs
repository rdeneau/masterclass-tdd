namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static string Of(int n)
        {
            if (n % 3 == 0)
                return "Foo";

            var s = $"{n}";
            if (s.Contains("3"))
                return "Foo";

            return s;
        }
    }
}