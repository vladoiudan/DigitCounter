using System.Collections.Generic;
using Iris.DigitCounter.Engine.Model;

namespace Iris.DigitCounter.Engine.Interfaces
{
    public interface IDigitCounter
    {
        IEnumerable<Digit> CountDigits(long upperRange);
    }
}