namespace FooBarQixKata
{
    public class MultipleOfMatch : Match
    {
        public int Prime { get; }

        public MultipleOfMatch(string word, int prime) : base(word)
        {
            Prime = prime;
        }

        public override bool Test(int number) =>
            number.IsMultipleOf(Prime);
    }
}