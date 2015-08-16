using System;
using System.Collections.Generic;
using Iris.DigitCounter.Engine.Interfaces;
using Iris.DigitCounter.Engine.Model;

namespace Iris.DigitCounter.Engine
{
    public class MathematicalDigitCounterEngine : IDigitCounter
    {
        public IEnumerable<Digit> CountDigits(long upperRange)
        {
            if (upperRange == 0)
            {
                yield return new Digit();
                yield break;
            }
            for (int i = 0; i < 10; i++)
            {
                yield return CountDigitOccurency(i, upperRange);
            }
        }

        private Digit CountDigitOccurency(int digit, long upperRange, bool inner = false)
        {
            if (upperRange == 0)
                return new Digit(upperRange, 0);

            var n = (long)Math.Floor(Math.Log10(upperRange));
            var m = (long)Math.Floor((upperRange + 1) / Math.Pow(10, n));
            var r = (long)(upperRange - m * Math.Pow(10, n));
            return new Digit(digit, (long)(
                (Math.Max(m, 1) * n * Math.Pow(10, n - 1)) +                            // Frequency of any digit up to highest power of 10 (0-99, etc.)
                ((digit < m) ? Math.Pow(10, n) : 0) +                                   // Frequency of Most Significant Digit above any multiple of highest power of 10 (100-399)
                (((r >= 0) && (n > 0)) ? CountDigitOccurency(digit, r, true).Occurencies : 0) +             // Frequency of any digits in remainder (400-445, R = 45)
                (((r >= 0) && (digit == m)) ? (r + 1) : 0) +                            // Additional frequency of Most Significant Digit in remainder
                (((r >= 0) && (digit == 0)) ? CountPaddingZeros(n, r) : 0) -            // Count zeros in middle position for remainder range (404, 405...)
                (((digit == 0) && !inner) ? CountLeadingZeros(n) : 0) -                 // Subtract leading zeros only once (on outermost loop)
                (((digit == 0) && !inner && r != 0 && upperRange > 10) ? 1 : 0)));      //remove one zero for ranges between 11-19, 21-29, etc
        }

        private long CountLeadingZeros(long n)
        {
            var counter = 0;
            do
            {
                counter = (int)Math.Pow(10, n) + counter;
                n--;
            } while (n > 0);
            return counter;
        }

        private long CountPaddingZeros(long n, long r)
        {
            return (long)((r + 1) * Math.Max(0, n - Math.Max(0, Math.Floor(Math.Log10(r))) - 1));
        }
    }
}
