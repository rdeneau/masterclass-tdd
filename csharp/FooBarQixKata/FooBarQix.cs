namespace FooBarQixKata
{
    public static class FooBarQix
    {
        public static string Of(int n)
        {
            if (n % 3 == 0)
                return "Foo";
            return $"{n}";
        }
    }
}