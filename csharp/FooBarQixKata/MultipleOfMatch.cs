namespace FooBarQixKata
{
    public class MultipleOfMatch : Match
    {
        public int Prime { get; }

        public string Word { get; }

        public MultipleOfMatch(int prime, string word)
        {
            Prime = prime;
            Word  = word;
        }

        public override bool Test(int number) =>
            number.IsMultipleOf(Prime);
    }
}