namespace Iris.DigitCounter.Engine.Model
{
    public struct Digit
    {
        public Digit(long value, long occurencies)
        {
            this.Value = value;
            this.Occurencies = occurencies;
        }

        public long Value;
        public long Occurencies;
    }
}