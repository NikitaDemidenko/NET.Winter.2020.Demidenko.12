using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using static IntegerExtensions.PrimeNumbers;

namespace IntegerExtensions.Tests
{
    public class PrimeNumbersTests
    {
        [Test]
        public void GetPrimeNumbers_InvalidCount_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new List<int>(GetPrimeNumbers(0)));

        [Test]
        public void GetPrimeNumbersTests()
        {
            var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71 };
            var actual = GetPrimeNumbers(20);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPrimeNumbersTests2()
        {
            var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 
                79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 };
            var actual = GetPrimeNumbers(46);
            Assert.AreEqual(expected, actual);
        }
    }
}
