namespace FooBarQixKata
{
    public abstract class Match
    {
        public string Word { get; }

        protected Match(string word)
        {
            Word  = word;
        }

        public abstract bool Test(int number);
        
    }
}