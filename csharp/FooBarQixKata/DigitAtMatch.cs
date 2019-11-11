namespace FooBarQixKata
{
    public class DigitAtMatch : Match
    {
        public int Digit { get; }

        public int Index { get; }

        public DigitAtMatch(string word, int digit, int index) : base(word)
        {
            Digit = digit;
            Index = index;
        }

        public override bool Test(int number)
        {
            var digitString = $"{Digit}";
            return $"{number}".Substring(Index, digitString.Length) == digitString;
        }
    }
}