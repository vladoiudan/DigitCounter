using System;
using System.Linq;
using Iris.DigitCounter.Engine.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.DigitCounter.Engine.Tests
{
    [TestClass]
    public class DigitCounterTest
    {
        private readonly IDigitCounter _digitCounter;

        public DigitCounterTest()
        {
            _digitCounter = new MathematicalDigitCounterEngine();
        }

        [TestMethod]
        public void TestCounterWithNLessThan10()
        {
            for (int i = 1; i < 10; i++)
            {
                var result = _digitCounter.CountDigits(i).ToList();
                for (int j = 1; j <= i; j++)
                {
                    Assert.IsTrue(result.ElementAt(j).Occurencies == 1);
                }
            }
        }

        [TestMethod]
        public void TestCounterWithNEquals19()
        {
                var result = _digitCounter.CountDigits(19).ToList();
                Assert.IsTrue(result.ElementAt(0).Occurencies == 1);
                Assert.IsTrue(result.ElementAt(1).Occurencies == 12);
                for (int j = 2; j <= 9; j++)
                {
                    Assert.IsTrue(result.ElementAt(j).Occurencies == 2);
                }
        }

        [TestMethod]
        public void TestCounterWithNEquals200()
        {
            var result = _digitCounter.CountDigits(200).ToList();
            Assert.IsTrue(result.ElementAt(0).Occurencies == 31);
            Assert.IsTrue(result.ElementAt(1).Occurencies == 140);
            Assert.IsTrue(result.ElementAt(2).Occurencies == 41);
            for (int j = 3; j <= 9; j++)
            {
                Assert.IsTrue(result.ElementAt(j).Occurencies == 40);
            }
        }

        [TestMethod]
        public void TestCounterWithNEquals1Milion()
        {
            var result = _digitCounter.CountDigits(1000000).ToList();
            Assert.IsTrue(result.ElementAt(0).Occurencies == 488895);
            Assert.IsTrue(result.ElementAt(1).Occurencies == 600001);
            for (int j = 2; j <= 9; j++)
            {
                Assert.IsTrue(result.ElementAt(j).Occurencies == 600000);
            }
        }

        [TestMethod]
        public void TestCounterWithNEquals10Power12()
        {
            var result = _digitCounter.CountDigits((long)Math.Pow(10,12)).ToList();
            Assert.IsTrue(result.ElementAt(0).Occurencies == 2201036372549);
            Assert.IsTrue(result.ElementAt(1).Occurencies == 1200000000001);
            for (int j = 2; j <= 9; j++)
            {
                Assert.IsTrue(result.ElementAt(j).Occurencies == 1200000000000);
            }
        }
    }
}
