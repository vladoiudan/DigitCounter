using System;
using Iris.DigitCounter.Engine.Interfaces;
using Microsoft.Practices.Unity;

namespace Iris.DigitCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                Bootstrapper.RegisterTypes(container);
                var digitCounter = container.Resolve<IDigitCounter>();
                string inputData;
                do
                {
                    Console.WriteLine("Enter the number of rooms or press (Q/q) for exit.");
                    Console.WriteLine();
                    Console.Write("N=");
                    inputData = Console.ReadLine();
                    if (inputData != null && inputData.ToLower() != "q")
                    {
                        long max;
                        if (long.TryParse(inputData, out max))
                        {
                            var result = digitCounter.CountDigits(max);
                            foreach (var digit in result)
                            {
                                Console.WriteLine("{0}: {1}", digit.Value, digit.Occurencies);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Number of rooms must be numeric!");
                        }
                    }
                } while (inputData != null && inputData.ToLower() != "q");
            }
        }
    }
}
